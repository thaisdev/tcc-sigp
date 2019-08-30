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
        private readonly IEmpresaAppService _empresaAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IEmpresaUsuarioAppService _empresaUsuarioAppService;
        private readonly IUnidadeUsuarioAppService _unidadeUsuarioAppService;

        public UsuarioController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IHostingEnvironment environment, UserManager<ApplicationUser> userManager, IEmailSender emailSender,
            IEmpresaAppService empresaAppService, IUnidadeAppService unidadeAppService,
            RoleManager<ApplicationRole> roleManager, IEmpresaUsuarioAppService empresaUsuarioAppService,
            IUnidadeUsuarioAppService unidadeUsuarioAppService) : base(
            notification, user)
        {
            _environment = environment;
            _userManager = userManager;
            _emailSender = emailSender;
            _empresaAppService = empresaAppService;
            _unidadeAppService = unidadeAppService;
            _roleManager = roleManager;
            _empresaUsuarioAppService = empresaUsuarioAppService;
            _unidadeUsuarioAppService = unidadeUsuarioAppService;
        }

        [Route("administrativo-usuarios/listar")]
        public IActionResult Index()
        {
            return View();
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
            var recordsTotal = 0;

            // Getting all Customer data
            IEnumerable<ApplicationUser> customerData = new List<ApplicationUser>();
            if (User.FindFirst("Perfil").Value == PerfilUsuarioEnum.Administrador.ToString())
            {
                customerData = (from tempcustomer in _userManager.Users.Where(x => x.LockoutEnabled).ToList()
                    select tempcustomer);
            }
            else
            {
                var empresaIds = _empresaUsuarioAppService.ObterTodos().Where(x => x.UsuarioId == UserId)
                    .Select(x => x.EmpresaId).ToList();

                var usuariosIds = new List<int>();

                foreach (var item in empresaIds)
                {
                    var id = int.Parse(item.ToString());
                    usuariosIds.AddRange(_empresaUsuarioAppService.ObterTodos().Where(x => x.EmpresaId == id)
                        .Select(x => x.UsuarioId));
                }

                foreach (var item in usuariosIds)
                {
                    var id = int.Parse(item.ToString());
                    customerData = _userManager.Users.Where(x => x.Id == id && x.LockoutEnabled).ToList();
                }
            }

            //Sorting
            if ((!string.IsNullOrEmpty(sortColumn) && (!string.IsNullOrEmpty(sortColumnDirection))))
            {
                if (sortColumnDirection == "desc")
                {
                    customerData = customerData.OrderByDescending(x => x.Equals(sortColumn));
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
            recordsTotal = customerData.Count();
            //Paging 
            var data = customerData.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data
            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data
            });
        }

        [Route("administrativo-usuarios/incluir-novo")]
        public IActionResult Create()
        {
            ViewBag.Empresas = FillEmpresas();
            return View();
        }

        [HttpPost]
        [Route("administrativo-usuarios/incluir-novo")]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            ViewBag.Empresas = FillEmpresas();

            if (model.Empresas != null)
            {
                if (model.PefilUsuario == PerfilUsuarioEnum.Gerente && model.Empresas.Count == 0 ||
                    model.PefilUsuario == PerfilUsuarioEnum.Operador && model.Empresas.Count == 0)
                {
                    ViewBag.RetornoPost = "error, Escolha a empresa.";
                    return View(model);
                }
            }

            if (!ModelState.IsValid)
            {
                var query = from state in ModelState.Values
                    from error in state.Errors
                    select error.ErrorMessage;

                var errorList = query.ToList();
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Nome = model.Nome,
                Email = model.Email,
                Imagem = "/Content/default-user.png",
                UnidadeId = model.UnidadeId,
                EmpresaId = model.EmpresaId,
                PefilUsuario = model.PefilUsuario,
                Cpf = model.Cpf
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            var perfilId = Convert.ToInt32(user.PefilUsuario);
            var perfil = _roleManager.Roles.FirstOrDefault(x => x.Id == perfilId);

            if (result.Succeeded)
            {
                if (perfil != null) await _userManager.AddToRoleAsync(user, perfil.Name);

                if (user.PefilUsuario.ToString() == PerfilUsuarioEnum.Gerente.ToString())
                {
                    if (model.Empresas != null)
                        foreach (var item in model.Empresas)
                        {
                            var empresaUsuario = new EmpresaUsuarioViewModel()
                            {
                                UsuarioId = user.Id,
                                EmpresaId = int.Parse(item)
                            };

                            _empresaUsuarioAppService.Adicionar(empresaUsuario);
                        }
                }
                else if (user.PefilUsuario.ToString() == PerfilUsuarioEnum.Operador.ToString())
                {
                    if (user.EmpresaId != null)
                    {
                        var empresaUsuario = new EmpresaUsuarioViewModel()
                        {
                            UsuarioId = user.Id,
                            EmpresaId = user.EmpresaId.Value
                        };
                        _empresaUsuarioAppService.Adicionar(empresaUsuario);
                    }

                    var unidadeUsuario = new UnidadeUsuarioViewModel()
                    {
                        UsuarioId = user.Id,
                        UnidadeId = int.Parse(model.UnidadeId.ToString())
                    };

                    _unidadeUsuarioAppService.Adicionar(unidadeUsuario);
                }
                else if (user.PefilUsuario.ToString() == PerfilUsuarioEnum.Operador_Unidades.ToString())
                {
                    if (model.Empresas != null)
                    {
                        foreach (var item in model.Empresas)
                        {
                            var id = int.Parse(item);
                            var empresaUsuario = new EmpresaUsuarioViewModel()
                            {
                                UsuarioId = user.Id,
                                EmpresaId = id
                            };

                            _empresaUsuarioAppService.Adicionar(empresaUsuario);
                        }
                    }
                }

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                Url.EmailConfirmationLink(user.Id.ToString(), code, Request.Scheme);

                await _emailSender.SendEmailAsync(model.Email, "Assunto", "Msg");
                ViewBag.RetornoPost = "success, Usuário cadastrado com sucesso";
                NovoUsuarioMail.EnviarEmail(model.Email, model.Email, model.Nome, model.Password);
                return View(null);
            }


            // If we got this far, something failed, redisplay form
            ViewBag.RetornoPost = "error, Erro ao tentar cadastrar usuário!";
            return View(model);
        }

        [Route("administrativo-usuarios/editar/")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("administrativo-usuarios/editar/")]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            if (!ModelState.IsValid) return View(user);

            var usuario = _userManager.Users.FirstOrDefault(x => x.Id == user.Id);
            var rolesForUser = await _userManager.GetRolesAsync(usuario);
            
            if (usuario != null)
            {
                usuario.Nome = user.Nome;
                usuario.Cpf = user.Cpf;
                usuario.Email = user.Email;
                usuario.PefilUsuario = user.PefilUsuario;

                var perfilId = Convert.ToInt32(user.PefilUsuario);
                var novoPerfil = _roleManager.Roles.FirstOrDefault(x => x.Id == perfilId);
                
                if (novoPerfil != null || user.PefilUsuario == PerfilUsuarioEnum.Operador_Unidades)
                {
                    if (rolesForUser != null)
                    {
                        foreach (var item in rolesForUser)
                        {
                            var deleteResult = await _userManager.RemoveFromRoleAsync(usuario, item);
                        }
                    }
                    if (novoPerfil != null) await _userManager.AddToRoleAsync(usuario, novoPerfil.Name);

                    await _userManager.UpdateAsync(usuario);

                    TempData["RetornoPost"] = "success, Usuário atualizado com sucesso!";
                    return View("Index");
                }
                
            }

            TempData["RetornoPost"] = "error, Erro ao tentar atualizar usuário!";
            return View("Index");
        }

        [HttpPost]
        [Route("administrativo-usuarios/excluir")]
        public IActionResult Delete(IFormCollection form)
        {
            var id = int.Parse(form["txtIdentify"]);

            var usuario = _userManager.Users.FirstOrDefault(x => x.Id == id);

            if (usuario != null)
            {
                usuario.LockoutEnabled = false;

                _userManager.UpdateAsync(usuario);
            }

            TempData["RetornoPost"] = "success, Usuário excluído com sucesso!";

            return Redirect("listar");
        }

        private MultiSelectList FillEmpresas()
        {
            var empresas = new List<EmpresaViewModel>();

            var perfilUsuario = User.FindFirst("Perfil").Value;

            // ReSharper disable once SuspiciousTypeConversion.Global
            if (perfilUsuario == PerfilUsuarioEnum.Administrador.ToString())
            {
                empresas = _empresaAppService.ObterTodosAtivos().ToList();
                var listEmp = new MultiSelectList(empresas, "Id", "RazaoSocial");
                return listEmp;
            }

            if (perfilUsuario == PerfilUsuarioEnum.Gerente.ToString())
            {
                var empresasId = _empresaUsuarioAppService.ObterTodos().Where(x => x.UsuarioId == UserId)
                    .Select(x => x.EmpresaId).ToList();

                //                var empresas = new List<IEnumerable<EmpresaViewModel>>();

                foreach (var item in empresasId)
                {
                    var id = int.Parse(item.ToString());
                    empresas.AddRange(_empresaAppService.ObterTodosAtivos().Where(x => x.Id == id).ToList());
                }

                var listEmp = new MultiSelectList(empresas, "Id", "RazaoSocial");
                return listEmp;
            }

            return null;
        }

        public JsonResult ListarUnidades(int id)
        {
            // Tomei uma liberdade poética aqui. Não sei se Get aceita
            // parâmetros, mas a título de exemplo, vamos supor que sim.
            var unidades = _unidadeAppService.ObterTodosAtivosPorEmpresa(id);

            return Json(unidades.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> ImportUsuarios(IFormCollection formData)
        {
            var file = HttpContext.Request.Form.Files;
            foreach (var formFile in file)
            {
                var userServerPath = _environment.WebRootPath + "/data/" + Guid.NewGuid() + "/";
                if (formFile.Length > 0)
                {
                    if (!Directory.Exists(userServerPath))
                    {
                        Directory.CreateDirectory(userServerPath);
                    }

                    var path = Path.Combine(userServerPath, formFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    using (var streamReader = System.IO.File.OpenText(userServerPath + formFile.FileName))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            var line = streamReader.ReadLine();
                            if (line != null)
                            {
                                var data = line.Split(new[] {';'});
                                var user = new ApplicationUser
                                {
                                    Id = int.Parse(data[0]),
                                    UserName = data[2],
                                    Nome = data[1],
                                    Email = data[2],
                                    Imagem = "/Content/default-user.png",
                                    Cpf = "N/A",
                                    EmpresaId = 0,
                                    UnidadeId = 0,
                                };
                                if (data[4] == "0")
                                    user.PefilUsuario = PerfilUsuarioEnum.Administrador;
                                else if (data[4] == "1")
                                    user.PefilUsuario = PerfilUsuarioEnum.Gerente;
                                else if (data[4] == "2" || data[4] == "3")
                                    user.PefilUsuario = PerfilUsuarioEnum.Operador;
                                var result = await _userManager.CreateAsync(user, "Virtus@2018");
                                var perfilId = Convert.ToInt32(user.PefilUsuario);
                                var perfil = _roleManager.Roles.FirstOrDefault(x => x.Id == perfilId);
                                if (result.Succeeded)
                                {
                                    if (perfil != null) await _userManager.AddToRoleAsync(user, perfil.Name);
                                    await _userManager.GenerateEmailConfirmationTokenAsync(user);
                                }
                            }
                        }
                    }
                }
            }

            return RedirectToAction("Index", "Usuario");
        }
    }
}