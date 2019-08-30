using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        [Route("administrativo-pedidos-compra/listar")]
        public IActionResult Compra()
        {
            return View();
        }
        
        // GET
        [Route("administrativo-pedidos-venda/listar")]
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