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
    public class VeiculoController : BaseController
    {
        private readonly IVeiculoAppService _veiculoAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public VeiculoController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IVeiculoAppService veiculoAppService) : base(notification, user)
        {
            _notification = notification;
            _veiculoAppService = veiculoAppService;
        }

        // GET
        [Route("administrativo-cadastro/veiculo")]
        public IActionResult Index()
        {
            return View();
        }

        // GET
        [Route("administrativo-cadastro/veiculos/incluir-novo")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(VeiculoViewModel model)
        {
            if (!ModelState.IsValid) return View("Create", model);

            _veiculoAppService.Adicionar(model);

            Erros();

            if (!OperacaoValida()) return View("Create", model);

            ViewBag.Sucesso = "Veículo cadastrado com sucesso!";

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

//        // GET
//        public IActionResult Edit()
//        {
//            return View();
//        }
//        
//        // GET
//        public IActionResult Delete()
//        {
//            return View();
//        }
    }
}