using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        // GET
        [Route("administrativo-cadastro/produto")]
        public IActionResult Index()
        {
            return View();
        }
        
        // GET
        [Route("administrativo-cadastro/produto-incluir-novo")]
        public IActionResult Create()
        {
            return View();
        }
        
//        // GET
//        [Route("administrativo-produto/editar")]
//        public IActionResult Edit()
//        {
//            return View();
//        }
//        
//        // GET
//        [Route("administrativo-produto/deletar")]
//        public IActionResult Delete()
//        {
//            return View();
//        }
    }
}