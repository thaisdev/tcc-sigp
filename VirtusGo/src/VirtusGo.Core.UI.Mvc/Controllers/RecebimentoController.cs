using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class RecebimentoController : Controller
    {
        [Route("administrativo-recebimento/analise-qualidade")]
        public IActionResult AnaliseQualidade()
        {
            return View();
        }
        
        [Route("administrativo-recebimento/conferencia-de-entrada")]
        public IActionResult ConferenciaEntrada()
        {
            return View();
        }
        
        [Route("administrativo-recebimento/conferencia-de-entrada-incluir")]
        public IActionResult CreateConferenciaEntrada()
        {
            return View();
        }
    }
}