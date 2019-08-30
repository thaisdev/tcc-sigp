using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class LogisticaController : Controller
    {
        [Route("administrativo-logistica/ordens-carga")]
        public IActionResult OrdensCarga()
        {
            return View();
        }
        
        [Route("administrativo-logistica/formacao-carga")]
        public IActionResult FormacaoCarga()
        {
            return View();
        }
        
        [Route("administrativo-logistica/fila-coletores")]
        public IActionResult FilaColetores()
        {
            return View();
        }
        
        [Route("administrativo-logistica/ordens-carga-incluir")]
        public IActionResult CreateOrdensCarga()
        {
            return View();
        }
        
        [Route("administrativo-logistica/formacao-carga-incluir")]
        public IActionResult CreateFormacaoCarga()
        {
            return View();
        }
        
        [Route("administrativo-logistica/fila-coletores-incluir")]
        public IActionResult CreateFilaColetores()
        {
            return View();
        }
    }
}