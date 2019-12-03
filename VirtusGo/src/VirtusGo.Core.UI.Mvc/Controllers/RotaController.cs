using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    public class RotaController : BaseController
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notification;
        private readonly IEnderecoAppService _enderecoAppService;
        private readonly IRotaAppService _rotaAppService;

        public RotaController(IDomainNotificationHandler<DomainNotification> notification, IUser user, IEnderecoAppService enderecoAppService, IRotaAppService rotaAppService) : base(notification, user)
        {
            _notification = notification;
            _enderecoAppService = enderecoAppService;
            _rotaAppService = rotaAppService;
        }

        [Route("/administrativo-cadastro/rotas/listar")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/administrativo-cadastro/rotas/incluir-novo")]
        public IActionResult Create()
        {
            ViewBag.FillEnderecos = FillEnderecos();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(RotaViewModel model)
        {
            ViewBag.FillEnderecos = FillEnderecos();

            if (!ModelState.IsValid) return View("Create", model);
            
            _rotaAppService.Adicionar(model);
            
            Erros();
            
            if(!OperacaoValida()) return View("Create", model);

            ViewBag.Sucesso = "Rota criada com Sucesso!";
            
            return View("Create", model);
        }
        
        private void Erros()
        {
            if (!_notification.HasNotifications()) return;
            foreach (var item in _notification.GetNotifications())
            {
                ModelState.AddModelError(String.Empty, item.Value);
            }
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