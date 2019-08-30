using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class EstoqueController : Controller
    {
        [Route("administrativo-estoque/beneficiamento")]
        public IActionResult Beneficiamento()
        {
            return View();
        }
        
        [Route("administrativo-estoque/ajuste-estoque")]
        public IActionResult AjusteEstoque()
        {
            return View();
        }
        
        [Route("administrativo-estoque/kardex")]
        public IActionResult Kardex()
        {
            return View();
        }
    }
}