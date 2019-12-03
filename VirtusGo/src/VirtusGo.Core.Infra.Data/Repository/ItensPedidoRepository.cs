using VirtusGo.Core.Domain.ItensPedidos;
using VirtusGo.Core.Domain.ItensPedidos.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class ItensPedidoRepository : Repository<ItensPedido>, IItensPedidoRepository
    {
        public ItensPedidoRepository(VirtusContext context) : base(context)
        {
        }
    }
}