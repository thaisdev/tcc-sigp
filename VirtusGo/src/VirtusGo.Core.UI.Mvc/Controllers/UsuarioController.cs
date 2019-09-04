using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Infra.CrossCutting.Identity.Services;
using VirtusGo.Core.Infra.CrossCutting.Mail;
using VirtusGo.Core.UI.Mvc.Models;
using VirtusGo.Core.UI.Mvc.Models.AccountViewModels;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IHostingEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UsuarioController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IHostingEnvironment environment, UserManager<ApplicationUser> userManager, IEmailSender emailSender,
            RoleManager<ApplicationRole> roleManager) : base(notification, user)
        {
            _environment = environment;
            _userManager = userManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [Route("administrativo-cadastro/usuarios")]
        public IActionResult Index()
        {
            return View();
        }
    }
}