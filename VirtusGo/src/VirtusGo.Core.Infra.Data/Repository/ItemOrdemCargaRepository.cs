using VirtusGo.Core.Domain.ItemOrdemCarga;
using VirtusGo.Core.Domain.ItemOrdemCarga.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class ItemOrdemCargaRepository : Repository<ItemOrdemCarga>, IItemOrdemCargaRepository
    {
        public ItemOrdemCargaRepository(VirtusContext context) : base(context)
        {
        }
    }
}