using VirtusGo.Core.Domain.Motoristas;
using VirtusGo.Core.Domain.Motoristas.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class MotoristaRepository : Repository<Motorista>, IMotoristaRepository
    {
        public MotoristaRepository(VirtusContext context) : base(context)
        {
        }
    }
}