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
    public class ParceiroController : BaseController
    {
        private readonly IParceiroAppService _parceiroAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;
        private readonly IEnderecoAppService _enderecoAppService;
        private readonly ICidadeAppService _cidadeAppService;

        public ParceiroController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IParceiroAppService parceiroAppService, IEnderecoAppService enderecoAppService,
            ICidadeAppService cidadeAppService) : base(notification, user)
        {
            _notification = notification;
            _parceiroAppService = parceiroAppService;
            _enderecoAppService = enderecoAppService;
            _cidadeAppService = cidadeAppService;
        }

        [Route("administrativo-cadastro/parceiros")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("administrativo-cadastro/parceiros/incluir-novo")]
        public IActionResult Create()
        {
            ViewBag.FillEnderecos = FillEnderecos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(ParceiroViewModel model)
        {
            ViewBag.FillEnderecos = FillEnderecos();
            if (!ModelState.IsValid) return View("Create", model);

            _parceiroAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("Create", model);

            ViewBag.Sucesso = "Parceiro cadastrado com sucesso!";
            return View("Index");
        }
        
        [Route("administrativo-cadastro/parceiros/editar")]
        public IActionResult Edit(int id)
        {
            ViewBag.FillEnderecos = FillEnderecos();
            var parceiro = _parceiroAppService.ObterTodos().FirstOrDefault(x => x.Id == id);
            return View(parceiro);
        }

        public IActionResult EditConfirmed(CidadeViewModel model)
        {
            ViewBag.FillEnderecos = FillEnderecos();
            if (!ModelState.IsValid) return View("Edit", model);

            _cidadeAppService.Atualizar(model);

            Erros();

            if (!OperacaoValida()) return View("Edit", model);

            ViewBag.Sucesso = "Parceiro atualizado com sucesso!";
            return View("Index");
        }

        [HttpPost]
        public IActionResult Delete(IFormCollection formCollection)
        {
            var id = int.Parse(formCollection["txtIdentify"].ToString());

            _parceiroAppService.Excluir(id);

            Erros();

            if (!OperacaoValida())
            {
                ViewBag.Error = "Falha ao tentar excluir!";
            }

            ViewBag.Sucesso = "Parceiro excluído com sucesso!";
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

        private List<SelectListItem> FillEnderecos()
        {
            var endereco = _enderecoAppService.ObterTodosQueriable();

            var enderecos = endereco.Select(item => new
            {
                item.Id,
                Logradouro = item.Logradouro + ", " + item.Numero + ", " + item.Bairro + ", " + item.Cidade.NomeCidade +
                             " - " +
                             item.Cidade.Estado.SiglaEstado
            }).Cast<object>().ToList();

            return new SelectList(enderecos, "Id", "Logradouro").ToList();
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
            var customerData = (from tempcustomer in _parceiroAppService.ObterTodos()
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
                    m.Nome.Contains(searchValue) || m.Email.Contains(searchValue));
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