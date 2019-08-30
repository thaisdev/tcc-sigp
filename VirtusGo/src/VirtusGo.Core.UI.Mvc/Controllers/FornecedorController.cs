using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class FornecedorController : Controller
    {
        // GET
        [Route("administrativo-cadastro/fornecedor")]
        public IActionResult Index()
        {
            return View();
        }
        
        // GET
        [Route("administrativo-cadastro/fornecedor-incluir-novo")]
        public IActionResult Create()
        {
            return View();
        }
        
//        // GET
//        [Route("administrativo-fornecedor/editar")]
//        public IActionResult Edit()
//        {
//            return View();
//        }
//        
//        // GET
//        [Route("administrativo-fornecedor/deletar")]
//        public IActionResult Delete()
//        {
//            return View();
//        }
    }
}