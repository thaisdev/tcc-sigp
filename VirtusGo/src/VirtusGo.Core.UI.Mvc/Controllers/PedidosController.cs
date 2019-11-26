using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class PedidosController : BaseController
    {
        private readonly IPedidoAppService _pedidoAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public PedidosController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IPedidoAppService pedidoAppService) : base(notification, user)
        {
            _notification = notification;
            _pedidoAppService = pedidoAppService;   
        }

        [Route("administrativo-pedidos/compras")]
        public IActionResult Compra()
        {
            return View();
        }
        
        // GET
        [Route("administrativo-pedidos/vendas")]
        public IActionResult Venda()
        {
            return View();
        }
        
        [Route("administrativo-pedidos-compra/incluir-novo")]
        public IActionResult CreateCompra()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateCompraConfirmed(PedidoViewModel model)
        {
            if (!ModelState.IsValid) return View("Create", model);

            _pedidoAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("Create", model);

            ViewBag.Sucesso = "Pedido de compra cadastrado com sucesso!";
            return View("Index");
        }
        [Route("administrativo-cadastro/pedido/editar")]
        public IActionResult EditCompra(int id)
        {
            var Pedido = _pedidoAppService.ObterTodos().FirstOrDefault(x => x.Id == id);
            return View(Pedido);
        }

        public IActionResult EditCompraConfirmed(PedidoViewModel model)
        {
            if (!ModelState.IsValid) return View("Edit", model);

            _pedidoAppService.Atualizar(model);

            Erros();

            if (!OperacaoValida()) return View("Edit", model);

            ViewBag.Sucesso = "Pedido de compra atualizada com sucesso!";
            return View("Index");
        }
        public IActionResult DeleteCompra(IFormCollection formCollection)
        {
            var id = int.Parse(formCollection["txtIdentify"].ToString());

            _pedidoAppService.Excluir(id);

            Erros();

            if (!OperacaoValida())
            {
                ViewBag.Error = "Falha ao tentar excluir!";
            }

            ViewBag.Sucesso = "Pedido de compra excluída com sucesso!";
            return View("Index");
        }

        [Route("administrativo-pedidos-venda/incluir-novo")]
        public IActionResult CreateVenda()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateVendaConfirmed(PedidoViewModel model)
        {
            if (!ModelState.IsValid) return View("Create", model);

            _pedidoAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("Create", model);

            ViewBag.Sucesso = "Pedido de venda cadastrado com sucesso!";
            return View("Index");
        }
        [Route("administrativo-cadastro/pedido/editar")]
        public IActionResult EditVenda(int id)
        {
            var pedido = _pedidoAppService.ObterTodos().FirstOrDefault(x => x.Id == id);
            return View(pedido);
        }

        public IActionResult EditVendaConfirmed(PedidoViewModel model)
        {
            if (!ModelState.IsValid) return View("Edit", model);

            _pedidoAppService.Atualizar(model);

            Erros();

            if (!OperacaoValida()) return View("Edit", model);

            ViewBag.Sucesso = "Pedido de venda atualizado com sucesso!";
            return View("Index");
        }
        public IActionResult DeleteVenda(IFormCollection formCollection)
        {
            var id = int.Parse(formCollection["txtIdentify"].ToString());

            _pedidoAppService.Excluir(id);

            Erros();

            if (!OperacaoValida())
            {
                ViewBag.Error = "Falha ao tentar excluir!";
            }

            ViewBag.Sucesso = "Pedido de venda excluída com sucesso!";
            return View("Index");
        }

        private void Erros()
        {
            if (!_notification.HasNotifications()) return;
            foreach (var item in _notification.GetNotifications())
            {
                ModelState.AddModelError(String.Empty, item.Value);
            }
        }

        public IActionResult GetGridData()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            // Skiping number of Rows count
            var start = Request.Form["start"].FirstOrDefault();
            // Paging Length 10,20
            var length = Request.Form["length"].FirstOrDefault();
            // Sort Column Name
            var sortColumn = Request
                .Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            // Sort Column Direction ( asc ,desc)
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            // Search Value from (Search box)
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10,20,50,100)
            var pageSize = length != null ? Convert.ToInt32(length) : 0;
            var skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal;

            // Getting all Customer data
            var customerData = (from tempcustomer in _pedidoAppService.ObterTodosQueriable()
                                select tempcustomer);

            //Sorting
            if ((!string.IsNullOrEmpty(sortColumn) && (!string.IsNullOrEmpty(sortColumnDirection))))
            {
                if (sortColumnDirection == "desc")
                {
                    customerData = customerData.OrderByDescending(x => false);
                }
                else
                    customerData = customerData.AsQueryable();
            }

            ////Search
            //if (!string.IsNullOrEmpty(searchValue))
            //{
            //    customerData = customerData.Where(m =>
            //        m.NomeCidade.Contains(searchValue));
            //}

            //total number of rows count 
            var estadoViewModels = customerData.ToList();
            recordsTotal = estadoViewModels.Count();
            //Paging 
            var data = estadoViewModels.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data
            return Json(new
            {
                draw,
                recordsFiltered = recordsTotal,
                recordsTotal,
                data
            });
        }
    }
}