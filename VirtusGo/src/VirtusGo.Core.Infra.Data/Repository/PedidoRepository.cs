using System.Collections.Generic;
using VirtusGo.Core.Domain.Pedido;
using VirtusGo.Core.Domain.Pedido.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(VirtusContext context) : base(context)
        {
        }

        public IEnumerable<Pedido> ObterTodosQueriable()
        {
            throw new System.NotImplementedException();
        }
    }
}