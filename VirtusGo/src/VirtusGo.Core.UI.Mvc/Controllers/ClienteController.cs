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
        private readonly IBeneficiarioAppService _beneficiarioAppService;
        private readonly IEmpresaAppService _empresaAppService;
        private readonly IUnidadeAppService _unidadeAppService;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;
        private readonly IUnidadeUsuarioAppService _unidadeUsuarioAppService;
        private readonly IEmpresaUsuarioAppService _empresaUsuarioAppService;

        public ClienteController(IDomainNotificationHandler<DomainNotification> notification, IUser user,
            IUnidadeAppService unidadeAppService, IBeneficiarioAppService beneficiarioAppService,
            IEmpresaAppService empresaAppService, IHostingEnvironment environment,
            IUnidadeUsuarioAppService unidadeUsuarioAppService, IEmpresaUsuarioAppService empresaUsuarioAppService) :
            base(notification, user)
        {
            _unidadeAppService = unidadeAppService;
            _empresaAppService = empresaAppService;
            _environment = environment;
            _unidadeUsuarioAppService = unidadeUsuarioAppService;
            _empresaUsuarioAppService = empresaUsuarioAppService;
            _beneficiarioAppService = beneficiarioAppService;
            _notification = notification;
        }

        [Route("administrativo-cadastro/cliente")]
        public IActionResult Index()
        {
            ViewBag.Emp = FillEmpresas();
            return View();
        }

        public IActionResult GetGridData(string pesquisar)
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
            var customerData = (from tempcustomer in _beneficiarioAppService.ObterTodosAtivos()
                select tempcustomer);

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
            if (!string.IsNullOrEmpty(pesquisar))
            {
                customerData = customerData.Where(m =>
                    m.Nome.Contains(pesquisar) || m.Email.Contains(pesquisar) ||
                    m.Telefone.Contains(pesquisar) || m.NumeroDocumento.Contains(pesquisar));
                
                //total number of rows count 
                recordsTotal = customerData.Count();
                //Paging 
                var d = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data
                return Json(new
                {
                    draw = draw,
                    recordsFiltered = recordsTotal,
                    recordsTotal = recordsTotal,
                    data = d
                });
            }

            //total number of rows count 
            recordsTotal = 0;
            //Paging 
            var data = customerData.Skip(skip).Take(0).ToList();
            //Returning Json Data
            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data
            });
        }

        public IActionResult GetGridDataInativos()
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
            var customerData = (from tempcustomer in _beneficiarioAppService.ObterTodosInativos()
                select tempcustomer);

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
                    m.Nome.Contains(searchValue) || m.Email.Contains(searchValue) ||
                    m.Telefone.Contains(searchValue));
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

        [Route("administrativo-cadastro/cliente-incluir-novo")]
        public IActionResult Create()
        {
            ViewBag.Ufs = FillEstados();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("administrativo-cadastro/cliente-incluir-novo")]
        public IActionResult Create(BeneficiarioViewModel beneficiarioViewModel)
        {
            ViewBag.Ufs = FillEstados();

            beneficiarioViewModel.UsuarioCriacaoId = UserId;
            beneficiarioViewModel.Excluido = FlagExcluidoEnum.nao;

            if (!ModelState.IsValid) return View(beneficiarioViewModel);

            _beneficiarioAppService.Adicionar(beneficiarioViewModel);

            if (OperacaoValida())
            {
                ViewBag.Sucesso = "Beneficiário Cadastrado com sucesso!";
                ModelState.Clear();
                
                //TODO: Enviar Email pós cadastro
                var userName = User.FindFirst("Nome");
                NovoBeneficiarioMail.EnviarEmail(beneficiarioViewModel.Email, beneficiarioViewModel, userName.Value);
                return View();
            }

            foreach (var item in _notification.GetNotifications())
            {
                ModelState.AddModelError(string.Empty, item.Value);
            }

            return View(beneficiarioViewModel);
        }

        [Route("administrativo-clientes/editar/")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Edit(int? id)
        {
            ViewBag.Ufs = FillEstados();
            if (id == null)
            {
                return NotFound();
            }

            var beneficiarioViewModel = _beneficiarioAppService.ObterPorBeneficiarioId(id.Value);

            if (beneficiarioViewModel == null)
            {
                return NotFound();
            }

            return View(beneficiarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("administrativo-clientes/editar/")]
        public IActionResult Edit(BeneficiarioViewModel beneficiarioViewModel)
        {
            ViewBag.Ufs = FillEstados();

            beneficiarioViewModel.UsuarioAlteracaoId = UserId;
            beneficiarioViewModel.DataAlteracao = DateTime.Now;

            if (!ModelState.IsValid) return View(beneficiarioViewModel);

            _beneficiarioAppService.Atualizar(beneficiarioViewModel);

            if (!OperacaoValida()) return View(beneficiarioViewModel);

            ViewBag.Sucesso = "Beneficiário Atualizado com sucesso!";
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public IActionResult DeleteConfirmed(IFormCollection data)
        {
            var id = data["txtIdentify"];
            var beneficiarioViewModel = _beneficiarioAppService.ObterPorBeneficiarioId(int.Parse(id));
            beneficiarioViewModel.UsuarioCriacaoId = UserId;
            beneficiarioViewModel.DataAlteracao = DateTime.Now;
            _beneficiarioAppService.DesativarPorId(beneficiarioViewModel);

            if (!OperacaoValida()) return RedirectToAction("Index");
            ViewBag.Sucesso = "Beneficiário Excluído com sucesso!";
            ViewBag.Emp = FillEmpresas();
            return View("Index");
        }

        [Route("administrativo-clientes/listar-inativos")]
        public ActionResult RecuperarInativos()
        {
            var beneficiariosInetivos = _beneficiarioAppService.ObterTodosInativos();
            return View(beneficiariosInetivos);
        }

        [Route("administrativo-clientes/listar-inativos")]
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult RecuperarInativos(IFormCollection form)
        {
            var id = form["txtId"];
            var beneficiario = _beneficiarioAppService.ObterPorBeneficiarioId(Convert.ToInt32(id));

            if (beneficiario == null)
            {
                ViewData.ModelState.AddModelError(string.Empty, "Falha ao tentar reativar beneficiário");
                return View("Index");
            }

            if (beneficiario.Excluido == FlagExcluidoEnum.nao)
            {
                ViewData.ModelState.AddModelError(string.Empty, "Beneficiário já está ativo");
                return View("Index");
            }

            _beneficiarioAppService.ReativarPorId(Convert.ToInt32(id));
            if (!OperacaoValida()) return View();
            ViewBag.Sucesso = "Beneficiário Reativado com sucesso!";
            return View();
        }

        public JsonResult ListarUnidades(int id)
        {
            // Tomei uma liberdade poética aqui. Não sei se Get aceita
            // parâmetros, mas a título de exemplo, vamos supor que sim.
            if (User.FindFirst("Perfil").Value == PerfilUsuarioEnum.Administrador.ToString())
            {
                var unidades = _unidadeAppService.ObterTodosAtivosPorEmpresa(id);
                return Json(unidades.ToList());
            }

            if (User.FindFirst("Perfil").Value == PerfilUsuarioEnum.Operador.ToString())
            {
                var unidadesId = _unidadeUsuarioAppService.ObterTodos().Where(x => x.UsuarioId == UserId).Select(x=>x.UnidadeId).ToList();
                var unidades = new List<UnidadeViewModel>();

                foreach (var item in unidadesId)
                {
                    var unidadeid = int.Parse(item.ToString());
                    unidades.Add(_unidadeAppService.ObterPorUnidadeId(unidadeid));
                }

                return Json(unidades.ToList());
            }
            else
            {
                var unidades = _unidadeAppService.ObterTodosAtivosPorEmpresa(id);
                return Json(unidades.ToList());
            }
        }

        private static IEnumerable<SelectListItem> FillEstados()
        {
            var items = new List<SelectListItem>();
            items.AddRange(Util.UfList().Select(x => new SelectListItem {Value = x, Text = x}));
            return items;
        }

        private List<SelectListItem> FillEmpresas()
        {
            if (User.FindFirst("Perfil").Value == PerfilUsuarioEnum.Administrador.ToString())
            {
                var empresas = _empresaAppService.ObterTodosAtivos();
                var listEmp = new SelectList(empresas, "Id", "NomeFantasia").ToList();
                return listEmp.ToList();
            }

            if (User.FindFirst("Perfil").Value == PerfilUsuarioEnum.Gerente.ToString() ||
                User.FindFirst("Perfil").Value == PerfilUsuarioEnum.Operador_Unidades.ToString())
            {
                var empresasIds = _empresaAppService.ObterEmpresasIdPorUsuario(UserId);

                var empresas = new List<EmpresaViewModel>();

                foreach (var item in empresasIds)
                {
                    var id = int.Parse(item.ToString());
                    empresas.Add(_empresaAppService.ObterPorEmpresaId(id));
                }

                var listEmp = new SelectList(empresas, "Id", "NomeFantasia").ToList();
                return listEmp.ToList();
            }

            if (User.FindFirst("Perfil").Value != PerfilUsuarioEnum.Operador.ToString()) return null;
            {
                var empresaId = _empresaAppService.ObterEmpresasIdPorUsuario(UserId);

                var empresas = new List<EmpresaViewModel>();

                foreach (var item in empresaId)
                {
                    var id = int.Parse(item.ToString());
                    empresas.Add(_empresaAppService.ObterPorEmpresaId(id));
                }

                var listEmp = new SelectList(empresas, "Id", "NomeFantasia").ToList();
                return listEmp.ToList();
            }
        }

        [Route("administrativo-clientes/importar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ImportBeneficiarios(IFormCollection formData)
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

                    var erroCount = 0;
                    using (var streamReader = System.IO.File.OpenText(userServerPath + formFile.FileName))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            var line = streamReader.ReadLine();
                            if (line != null)
                            {
                                var data = line.Split(new[] {';'});

                                var beneficiario = new BeneficiarioViewModel()
                                {
                                    Id = int.Parse(data[0]),
                                    Nome = data[1],
                                    NumeroDocumento = data[3],
                                    Ddd = data[4],
                                    Telefone = data[5],
                                    Email = data[6],
                                    Cep = data[7],
                                    Bairro = data[8],
                                    Endereco = data[9],
                                    Uf = data[10],
                                    Cidade = data[11],
                                    UsuarioCriacaoId = int.Parse(User.GetUserId()),
                                };

                                var pf = (int) TipoPessoaEnum.Pf;
                                var excluido = (int) FlagExcluidoEnum.sim;

                                if (int.Parse(data[12]) == excluido)
                                    beneficiario.Excluido = FlagExcluidoEnum.sim;
                                else
                                    beneficiario.Excluido = FlagExcluidoEnum.nao;

                                if (int.Parse(data[2]) == pf)
                                    beneficiario.TipPessoa = TipoPessoaEnum.Pf;
                                else
                                    beneficiario.TipPessoa = TipoPessoaEnum.Pj;

                                if (data[14] != "")
                                {
                                    beneficiario.UsuarioAlteracaoId = int.Parse(data[14]);
                                }

                                _beneficiarioAppService.Adicionar(beneficiario);

                                if (!OperacaoValida())
                                {
                                    erroCount = erroCount + 1;
                                    foreach (var msg in _notification.GetNotifications())
                                    {
                                        ModelState.AddModelError(String.Empty, msg.Value);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ModelState.AddModelError(String.Empty, "Nenhum arquivo foi importado.");
            return View("Import");
        }
    }
}