using VirtusGo.Core.Domain.Veiculo;
using VirtusGo.Core.Domain.Veiculo.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(VirtusContext context) : base(context)
        {
        }
    }
}