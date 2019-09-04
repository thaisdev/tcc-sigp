using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        [Route("administrativo-pedidos/compras")]
        public IActionResult Compra()
        {
            return View();
        }
        
        // GET
        [Route("administrativo-pedidos/vendas")]
        public IActionResult Venda()
        {
            return View();
        }
        
        [Route("administrativo-pedidos-compra/incluir-novo")]
        public IActionResult CreateCompra()
        {
            return View();
        }
        
        [Route("administrativo-pedidos-venda/incluir-novo")]
        public IActionResult CreateVenda()
        {
            return View();
        }
    }
}