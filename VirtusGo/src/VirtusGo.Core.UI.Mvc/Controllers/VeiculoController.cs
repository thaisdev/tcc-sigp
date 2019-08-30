using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class VeiculoController : Controller
    {
        // GET
        [Route("administrativo-cadastro/veiculo")]
        public IActionResult Index()
        {
            return View();
        }
        
        // GET
        [Route("administrativo-cadastro/veiculo-incluir-novo")]
        public IActionResult Create()
        {
            return View();
        }
        
//        // GET
//        public IActionResult Edit()
//        {
//            return View();
//        }
//        
//        // GET
//        public IActionResult Delete()
//        {
//            return View();
//        }
    }
}