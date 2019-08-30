using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class MotoristaController : Controller
    {
        // GET
        [Route("administrativo-cadastro/motorista")]
        public IActionResult Index()
        {
            return View();
        }
        
        // GET
        [Route("administrativo-cadastro/motorista-incluir-novo")]
        public IActionResult Create()
        {
            return View();
        }
        
//        // GET
//        [Route("administrativo-motorista/editar")]
//        public IActionResult Edit()
//        {
//            return View();
//        }
//        
//        // GET
//        [Route("administrativo-motorista/deletar")]
//        public IActionResult Delete()
//        {
//            return View();
//        }
    }
}