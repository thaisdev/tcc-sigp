using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public ParceiroController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IParceiroAppService parceiroAppService) : base(notification, user)
        {
            _parceiroAppService = parceiroAppService;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // GET
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CreateConfirmed(ParceiroViewModel model)
        {
            return View("Index");
        }
    }
}