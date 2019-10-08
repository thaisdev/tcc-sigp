using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Infra.CrossCutting.Mail;
using VirtusGo.Core.UI.Mvc.Models;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class ClienteController : BaseController
    {
        private readonly IHostingEnvironment _environment;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public ClienteController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IHostingEnvironment environment) : base(notification, user)
        {
            _environment = environment;
            _notification = notification;
        }

        [Route("administrativo-cadastro/cliente")]
        public IActionResult Index()
        {
            return View();
        }
    }
}