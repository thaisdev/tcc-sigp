using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class RelatorioController : Controller
    {
        
        [Route(("administrativo-relatorio/compra"))]
        public IActionResult Compra()
        {
            return
            View();
        }
        
        [Route(("administrativo-relatorio/venda"))]
        public IActionResult Venda()
        {
            return
                View();
        }
        
        [Route(("administrativo-relatorio/produto-validade"))]
        public IActionResult ProdutoValidade()
        {
            return
                View();
        }
    }
}