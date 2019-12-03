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
    public class LogisticaController : BaseController
    {
        private readonly IOrdemCargaAppService _ordemCargaAppService;
        private readonly IMotoristaAppService _motoristaAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;
        private readonly IVeiculoAppService _veiculoAppService;
        private readonly IEnderecoAppService _enderecoAppService;
        private readonly IRotaAppService _rotaAppService;

        public LogisticaController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IOrdemCargaAppService ordemCargaAppService, IMotoristaAppService motoristaAppService,
            IVeiculoAppService veiculoAppService, IEnderecoAppService enderecoAppService,
            IRotaAppService rotaAppService) : base(notification, user)
        {
            _ordemCargaAppService = ordemCargaAppService;
            _motoristaAppService = motoristaAppService;
            _notification = notification;
            _veiculoAppService = veiculoAppService;
            _enderecoAppService = enderecoAppService;
            _rotaAppService = rotaAppService;
        }

        [Route("administrativo-logistica/ordens-carga")]
        public IActionResult OrdensCarga()
        {
            return View();
        }

        [Route("administrativo-logistica/ordens-carga-incluir")]
        public IActionResult CreateOrdensCarga()
        {
            ViewBag.FillMotorista = FillMotorista();
            ViewBag.FillVeiculo = FillVeiculo();
            ViewBag.FillEnderecos = FillEnderecos();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateConfirmedOrdensCarga(OrdemCargaViewModel model)
        {
            ViewBag.FillMotorista = FillMotorista();
            ViewBag.FillVeiculo = FillVeiculo();
            ViewBag.FillEnderecos = FillEnderecos();
            if (!ModelState.IsValid) return View("CreateOrdensCarga", model);

            _ordemCargaAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("CreateOrdensCarga", model);

            ViewBag.Sucesso = "Ordem de carga cadastrada com sucesso!";
            return View("OrdensCarga");
        }

        [Route("administrativo-logistica/formacao-carga")]
        public IActionResult FormacaoCarga()
        {
            return View();
        }

        [Route("administrativo-logistica/fila-coletores")]
        public IActionResult FilaColetores()
        {
            return View();
        }

        [Route("administrativo-logistica/formacao-carga-incluir")]
        public IActionResult CreateFormacaoCarga()
        {
            return View();
        }

        [Route("administrativo-logistica/fila-coletores-incluir")]
        public IActionResult CreateFilaColetores()
        {
            return View();
        }

        private void Erros()
        {
            if (!_notification.HasNotifications()) return;
            foreach (var item in _notification.GetNotifications())
            {
                ModelState.AddModelError(String.Empty, item.Value);
            }
        }

        private List<SelectListItem> FillMotorista()
        {
            var motorista = _motoristaAppService.ObterTodos();
            return new SelectList(motorista, "Id", "Nome").ToList();
        }

        private List<SelectListItem> FillVeiculo()
        {
            var veiculos = _veiculoAppService.ObterTodos();
            return new SelectList(veiculos, "Id", "Modelo").ToList();
        }

        private List<SelectListItem> FillEnderecos()
        {
            var endereco = _enderecoAppService.ObterTodosQueriable();

            var enderecos = endereco.Select(item => new
            {
                _rotaAppService.ObterPorEnderecoId(item.Id).Id,
                Logradouro = item.Logradouro + ", " + item.Numero + ", " + item.Bairro + ", " + item.Cidade.NomeCidade +
                             " - " +
                             item.Cidade.Estado.SiglaEstado
            }).Cast<object>().ToList();

            return new SelectList(enderecos, "Id", "Logradouro").ToList();
        }

        [Route("administrativo-logistica/editar")]
        public IActionResult EditOrdemCarga(int id)
        {
            ViewBag.FillMotorista = FillMotorista();
            ViewBag.FillVeiculo = FillVeiculo();
            ViewBag.FillEnderecos = FillEnderecos();
            var oc = _ordemCargaAppService.ObterTodos().FirstOrDefault(x => x.Id == id);
            return View(oc);
        }

        public IActionResult EditOrdemCargaConfirmed(OrdemCargaViewModel model)
        {
            ViewBag.FillMotorista = FillMotorista();
            ViewBag.FillVeiculo = FillVeiculo();
            ViewBag.FillEnderecos = FillEnderecos();
            if (!ModelState.IsValid) return View("EditOrdemCarga", model);

            _ordemCargaAppService.Atualizar(model);

            Erros();

            if (!OperacaoValida()) return View("EditOrdemCarga", model);

            ViewBag.Sucesso = "Ordem atualizada com sucesso!";
            return View("OrdensCarga");
        }

        [HttpPost]
        public IActionResult DeleteOrdemCarga(IFormCollection formCollection)
        {
            var id = int.Parse(formCollection["txtIdentify"].ToString());

            _ordemCargaAppService.Excluir(id);

            Erros();

            if (!OperacaoValida())
            {
                ViewBag.Error = "Falha ao tentar excluir!";
            }

            ViewBag.Sucesso = "Ordem excluída com sucesso!";
            return View("OrdensCarga");
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
            var customerData = (from tempcustomer in _ordemCargaAppService.ObterTodosQueriable()
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
                    m.Motorista.Nome.Contains(searchValue) || m.Rota.Endereco.Logradouro.Contains(searchValue) ||
                    m.Veiculo.Modelo.Contains(searchValue));
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