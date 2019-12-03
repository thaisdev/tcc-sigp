using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class EnderecamentoEstoqueController : BaseController
    {
        private readonly IEnderecoEstoqueAppService _enderecoEstoqueAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public EnderecamentoEstoqueController(IEnderecoEstoqueAppService enderecoEstoqueAppService, IDomainNotificationHandler<DomainNotification> notification, IUser user) : base(notification, user)
        {
            _enderecoEstoqueAppService = enderecoEstoqueAppService;
            _notification = notification;
        }
        
        
        // GET
        [Route("administrativo-cadastro/enderecamento-estoque")]
        public IActionResult Index()
        {
            return View();
        }
        
        // GET
        [Route("administrativo-cadastro/enderecamento-estoque-incluir-novo")]
        public IActionResult Create()
        {
            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateConfirmed(EnderecoEstoqueViewModel model)
        {
            if (!ModelState.IsValid) return View("Create", model);

            _enderecoEstoqueAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("Create", model);

            ViewBag.Sucesso = "Endereço de Estoque cadastrado com sucesso!";
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
        
    }
}