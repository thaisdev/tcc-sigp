using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class CondicaoPagamentoController : Controller
    {
        // GET
        [Route("administrativo-cadastro/condicao-pagamento")]
        public IActionResult Index()
        {
            return View();
        }
        
        // GET
        [Route("administrativo-cadastro/condicao-pagamento-incluir-novo")]
        public IActionResult Create()
        {
            return View();
        }
        
//        // GET
//        [Route("administrativo-condicao-pagamento/editar")]
//        public IActionResult Edit()
//        {
//            return View();
//        }
//        
//        // GET
//        [Route("administrativo-condicao-pagamento/deletar")]
//        public IActionResult Delete()
//        {
//            return View();
//        }
    }
}