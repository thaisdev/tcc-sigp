using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Pedido.Repository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        IEnumerable<Pedido> ObterTodosQueriable();
    }
}
