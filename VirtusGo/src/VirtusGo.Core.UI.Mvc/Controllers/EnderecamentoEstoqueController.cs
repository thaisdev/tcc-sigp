using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class EnderecamentoEstoqueController : Controller
    {
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
        
//        // GET
//        [Route("administrativo-enderecamento-estoque/listar")]
//        public IActionResult Edit()
//        {
//            return View();
//        }
//        
//        // GET
//        [Route("administrativo-enderecamento-estoque/listar")]
//        public IActionResult Delete()
//        {
//            return View();
//        }
    }
}