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
    public class EnderecoController : BaseController
    {
        private readonly IEnderecoAppService _enderecoAppService;
        private readonly ICidadeAppService _cidadeAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public EnderecoController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            ICidadeAppService cidadeAppService, IEnderecoAppService enderecoAppService) : base(notification, user)
        {
            _notification = notification;
            _cidadeAppService = cidadeAppService;
            _enderecoAppService = enderecoAppService;
        }

        [Route("administrativo-cadastro/enderecos")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("administrativo-cadastro/enderecos/incluir-novo")]
        public IActionResult Create()
        {
            ViewBag.FillCidades = FillCidades();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateConfirmed(EnderecoViewModel model)
        {
            if (!ModelState.IsValid) return View("Create", model);

            _enderecoAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("Create", model);

            ViewBag.Sucesso = "Endereço cadastrado com sucesso!";
            return View("Index");
        }

        [Route("administrativo-cadastro/endereco/editar")]
        public IActionResult Edit(int id)
        {
            ViewBag.FillCidades = FillCidades();
            var endereco = _enderecoAppService.ObterTodosQueriable().FirstOrDefault(x => x.Id == id);
            return View(endereco);
        }

        public IActionResult EditConfirmed(EnderecoViewModel model)
        {
            ViewBag.FillCidades = FillCidades();
            if (!ModelState.IsValid) return View("Edit", model);

            _enderecoAppService.Atualizar(model);

            Erros();

            if (!OperacaoValida()) return View("Edit", model);

            ViewBag.Sucesso = "Endereço atualizado com sucesso!";
            return View("Index");
        }
        
        [HttpPost]
        public IActionResult Delete(IFormCollection formCollection)
        {
            var id = int.Parse(formCollection["txtIdentify"].ToString());

            _enderecoAppService.Excluir(id);

            Erros();

            if (!OperacaoValida())
            {
                ViewBag.Error = "Falha ao tentar excluir!";
            }

            ViewBag.Sucesso = "Endereço excluíd0 com sucesso!";
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

        private List<SelectListItem> FillCidades()
        {
            var cidades = _cidadeAppService.ObterTodos();
            return new SelectList(cidades, "Id", "NomeCidade").ToList();
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
            var customerData = (from tempcustomer in _enderecoAppService.ObterTodosQueriable()
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
                    m.Bairro.Contains(searchValue));
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