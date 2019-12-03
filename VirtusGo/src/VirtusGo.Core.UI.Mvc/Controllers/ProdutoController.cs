using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public ProdutoController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IProdutoAppService produtoAppService) : base(notification, user)
        {
            _notification = notification;
            _produtoAppService = produtoAppService;
        }

        [Route("administrativo-cadastro/produtos")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("administrativo-cadastro/produtos/incluir-novo")]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateConfirmed(ProdutoViewModel model)
        {
            if (!ModelState.IsValid) return View("Create", model);

            _produtoAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("Create", model);

            ViewBag.Sucesso = "Produto cadastrado com sucesso!";
            return View("Index");
        }

        [Route("administrativo-cadastro/produto/editar")]
        public IActionResult Edit(int id)
        {
            var produto = _produtoAppService.ObterTodos().FirstOrDefault(x => x.Id == id);
            return View(produto);
        }

        public IActionResult EditConfirmed(ProdutoViewModel model)
        {
            if (!ModelState.IsValid) return View("Edit", model);

            _produtoAppService.Atualizar(model);

            Erros();

            if (!OperacaoValida()) return View("Edit", model);

            ViewBag.Sucesso = "Produto atualizado com sucesso!";
            return View("Index");
        }

        [HttpPost]
        public IActionResult Delete(IFormCollection formCollection)
        {
            var id = int.Parse(formCollection["txtIdentify"].ToString());

            _produtoAppService.Excluir(id);

            Erros();

            if (!OperacaoValida())
            {
                ViewBag.Error = "Falha ao tentar excluir!";
            }

            ViewBag.Sucesso = "Produto excluído com sucesso!";
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

        public IActionResult GetGridData(string pesquisar)
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
            var customerData = (from tempcustomer in _produtoAppService.ObterTodos()
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

            //Search
            if (!string.IsNullOrEmpty(searchValue))
            {
                customerData = customerData.Where(m =>
                    m.Descricao.Contains(searchValue));
            }

            if (!string.IsNullOrEmpty(pesquisar))
            {
                customerData = customerData.Where(x => x.Descricao.Contains(pesquisar))
                    .ToList();
            }

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