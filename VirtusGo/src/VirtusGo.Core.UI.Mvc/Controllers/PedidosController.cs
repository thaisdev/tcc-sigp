using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IProdutoAppService _produtoAppService;
        private readonly IParceiroAppService _parceiroAppService;
        private readonly IMotoristaAppService _motoristaAppService;
        private readonly ICondicaoFinanceiraAppService _condicaoFinanceiraAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public PedidosController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IPedidoAppService pedidoAppService, IProdutoAppService produtoAppService,
            IParceiroAppService parceiroAppService, IMotoristaAppService motoristaAppService,
            ICondicaoFinanceiraAppService condicaoFinanceiraAppService) : base(notification, user)
        {
            _pedidoAppService = pedidoAppService;
            _produtoAppService = produtoAppService;
            _parceiroAppService = parceiroAppService;
            _motoristaAppService = motoristaAppService;
            _condicaoFinanceiraAppService = condicaoFinanceiraAppService;
            _notification = notification;
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
//            ViewBag.FillProdutos = FillProdutos();
            ViewBag.FillMotoristas = FillMotoristas();
            ViewBag.FillParceirosk = FillParceiros();
            ViewBag.FillCondicaoPagamentos = FillCondicaoPagamentos();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateCompraConfirmed(PedidoViewModel model)
        {
            ViewBag.FillProdutos = FillProdutos();
            ViewBag.FillMotoristas = FillMotoristas();
            ViewBag.FillParceirosk = FillParceiros();
            ViewBag.FillCondicaoPagamentos = FillCondicaoPagamentos();

            model.TipoPedido = "Compra";
            model.VendedorCompradorId = UserId;
            model.DataNegociacaoPedido = DateTime.Now;
            model.PagamentoId = 1;

            if (!ModelState.IsValid) return View("CreateCompra", model);

            _pedidoAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("CreateCompra", model);

            ViewBag.Sucesso = "Pedido de compra cadastrado com sucesso!";
            var itemPedido = new SelecionarProdutosVIewModel()
            {
                // ReSharper disable once PossibleNullReferenceException
                PedidoId = _pedidoAppService.ObterTodos().LastOrDefault().Id
            };
            return View("ItemPedidos", itemPedido);
        }

        [Route("administrativo-pedidos-venda/incluir-novo")]
        public IActionResult CreateVenda()
        {
//            ViewBag.FillProdutos = FillProdutos();
            ViewBag.FillMotoristas = FillMotoristas();
            ViewBag.FillParceirosk = FillParceiros();
            ViewBag.FillCondicaoPagamentos = FillCondicaoPagamentos();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateVendaConfirmed(PedidoViewModel model)
        {
            ViewBag.FillProdutos = FillProdutos();
            ViewBag.FillMotoristas = FillMotoristas();
            ViewBag.FillParceirosk = FillParceiros();
            ViewBag.FillCondicaoPagamentos = FillCondicaoPagamentos();

            model.TipoPedido = "Venda";
            model.VendedorCompradorId = UserId;
            model.DataNegociacaoPedido = DateTime.Now;
            model.PagamentoId = 1;

            if (!ModelState.IsValid) return View("CreateVenda", model);

            _pedidoAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("CreateVenda", model);

            ViewBag.Sucesso = "Pedido de Venda cadastrado com sucesso!";
            var itemPedido = new SelecionarProdutosVIewModel()
            {
                // ReSharper disable once PossibleNullReferenceException
                PedidoId = _pedidoAppService.ObterTodos().LastOrDefault().Id
            };
            return View("ItemPedidos", itemPedido);
        }

        [Route("administrativo-pedidos-produto/selecionar")]
        public IActionResult ItemPedidos()
        {
            ViewBag.FillProdutos = FillProdutos();
            return View();
        }

        public IActionResult ItemPedidosConfirmed(SelecionarProdutosVIewModel model)
        {
            ViewBag.FillProdutos = FillProdutos();

            var listProdutos = model.Produtos.Select(item => new ListarProdutosViewModel()
                {
                    Id = item,
                    NomeProduto = _produtoAppService.ObterTodos().FirstOrDefault(x => x.Id == item)?.Descricao
                })
                .ToList();

            ViewBag.ListarProdutos = listProdutos;

            return View("QuantidadeProduto");
        }

        public IActionResult QuantidadeProduto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult QuantidadeProdutoConfirmed(IFormCollection data)
        {
            var t = @TempData["Data1"];
            return View("Compra");
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

        private List<SelectListItem> FillProdutos()
        {
            var produtos = _produtoAppService.ObterTodos();
            return new SelectList(produtos, "Id", "Descricao").ToList();
        }

        private List<SelectListItem> FillMotoristas()
        {
            var motoristas = _motoristaAppService.ObterTodos();
            return new SelectList(motoristas, "Id", "Nome").ToList();
        }

        private List<SelectListItem> FillParceiros()
        {
            var parceiros = _parceiroAppService.ObterTodos();
            return new SelectList(parceiros, "Id", "Nome").ToList();
        }

        private List<SelectListItem> FillCondicaoPagamentos()
        {
            var c = _condicaoFinanceiraAppService.ObterTodos();
            return new SelectList(c, "Id", "Parcelas").ToList();
        }
    }
}