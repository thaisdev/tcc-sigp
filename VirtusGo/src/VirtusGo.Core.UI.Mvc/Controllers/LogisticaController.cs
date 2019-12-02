using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
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

        public LogisticaController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IOrdemCargaAppService ordemCargaAppService, IMotoristaAppService motoristaAppService,
            IVeiculoAppService veiculoAppService, IEnderecoAppService enderecoAppService) : base(notification, user)
        {
            _ordemCargaAppService = ordemCargaAppService;
            _motoristaAppService = motoristaAppService;
            _notification = notification;
            _veiculoAppService = veiculoAppService;
            _enderecoAppService = enderecoAppService;
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
            return View("CreateOrdensCarga");
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
                item.Id,
                Logradouro = item.Logradouro + ", " + item.Numero + ", " + item.Bairro + ", " + item.Cidade.NomeCidade +
                             " - " +
                             item.Cidade.Estado.SiglaEstado
            }).Cast<object>().ToList();

            return new SelectList(enderecos, "Id", "Logradouro").ToList();
        }
    }
}