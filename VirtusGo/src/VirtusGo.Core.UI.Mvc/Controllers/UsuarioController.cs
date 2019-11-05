using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.UI.Mvc.Models;
using VirtusGo.Core.UI.Mvc.Models.AccountViewModels;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public UsuarioController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            UserManager<ApplicationUser> userManager) : base(notification, user)
        {
            _notification = notification;
            _userManager = userManager;
        }

        [Route("administrativo-cadastro/usuarios")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("administrativo-cadastro/usuarios/incluir-novo")]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateConfirmed(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View("Create", model);

            var user = new ApplicationUser
                {UserName = model.Email, Email = model.Email, Nome = model.Nome, Cpf = model.Cpf};
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, item.Description);
                }

                return View("Create", model);
            }

            ViewBag.Sucesso = "Usuário cadastrado com sucesso!";
            return View("Index");
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
            var customerData = (from tempcustomer in _userManager.Users.ToList()
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