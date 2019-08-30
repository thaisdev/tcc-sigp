using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class ExpediçãoController : Controller
    {
        [Route("administrativo-expedicao/conferencia-de-carga")]
        public IActionResult ConferenciaCarga()
        {
            return View();
        }
        
        [Route("administrativo-expedicao/emissao-de-nota-fiscal")]
        public IActionResult EmissaoNf()
        {
            return View();
        }
    }
}