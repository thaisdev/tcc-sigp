using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class VeiculoController : BaseController
    {
        private readonly IParceiroAppService _parceiroAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;
        private readonly IVeiculoAppService _veiculoAppService;

        public VeiculoController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IParceiroAppService parceiroAppService,
            IVeiculoAppService veiculoAppService) : base(notification, user)
        {
            _notification = notification;
            _parceiroAppService = parceiroAppService;
            _veiculoAppService = veiculoAppService;
        }

        [Route("administrativo-cadastro/veiculos")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("administrativo-cadastro/veiculos/incluir-novo")]
        public IActionResult Create()
        {
            ViewBag.FillParceiros = FillParceiros();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateConfirmed(VeiculoViewModel model)
        {
            ViewBag.FillParceiros = FillParceiros();
            if (!ModelState.IsValid) return View("Create", model);

            _veiculoAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("Create", model);

            ViewBag.Sucesso = "Veículo cadastrado com sucesso!";
            return View("Index");
        }
        
        [Route("administrativo-cadastro/veiculo/editar")]
        public IActionResult Edit(int id)
        {
            ViewBag.FillParceiros = FillParceiros();
            var veiculo = _veiculoAppService.ObterTodos().FirstOrDefault(x => x.Id == id);
            return View(veiculo);
        }

        public IActionResult EditConfirmed(VeiculoViewModel model)
        {
            if (!ModelState.IsValid) return View("Edit", model);

            _veiculoAppService.Atualizar(model);

            Erros();

            if (!OperacaoValida()) return View("Edit", model);

            ViewBag.Sucesso = "Produto atualizado com sucesso!";
            return View("Index");
        }

        [HttpPost]
        public IActionResult Delete(IFormCollection formCollection)
        {
            var id = int.Parse(formCollection["txtIdentify"].ToString());

            _veiculoAppService.Excluir(id);

            Erros();

            if (!OperacaoValida())
            {
                ViewBag.Error = "Falha ao tentar excluir!";
            }

            ViewBag.Sucesso = "Veículo excluído com sucesso!";
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

        private List<SelectListItem> FillParceiros()
        {
            var parceiros = _parceiroAppService.ObterTodos();
            return new SelectList(parceiros, "Id", "Nome").ToList();
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
            var customerData = (from tempcustomer in _veiculoAppService.ObterTodosQueriable()
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
                    m.Modelo.Contains(searchValue) || m.Marca.Contains(searchValue));
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