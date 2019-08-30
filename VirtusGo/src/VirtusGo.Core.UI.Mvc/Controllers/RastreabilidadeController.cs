using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class RastreabilidadeController : Controller
    {
        [Route("administrativo-rastreabilidade/impressao-etiqueta")]
        public IActionResult ImpressaoEtiqueta()
        {
            return View();
        }
        
        [Route("administrativo-rastreabilidade/modelo-etiqueta")]
        public IActionResult ModeloEtiqueta()
        {
            return View();
        }
        
        [Route("administrativo-rastreabilidade/rastreabilidade")]
        public IActionResult Rastreabilidade()
        {
            return View();
        }
        
        [Route("administrativo-rastreabilidade/vinculacao-caixa")]
        public IActionResult VinculacaoCaixa()
        {
            return View();
        }
        
        [Route("administrativo-rastreabilidade/rastreabilidade-incluir")]
        public IActionResult CreateRastreabilidade()
        {
            return View();
        }
        
        [Route("administrativo-rastreabilidade/vinculacao-caixa-incluir")]
        public IActionResult CreateVinculacao()
        {
            return View();
        }
    }
}