using VirtusGo.Core.Domain.Rota;
using VirtusGo.Core.Domain.Rota.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class RotaRepository : Repository<Rota>, IRotaRepository
    {
        public RotaRepository(VirtusContext context) : base(context)
        {
        }
    }
}