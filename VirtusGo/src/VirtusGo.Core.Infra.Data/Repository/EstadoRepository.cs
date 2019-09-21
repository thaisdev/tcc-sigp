using VirtusGo.Core.Domain.Estado;
using VirtusGo.Core.Domain.Estado.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class EstadoRepository : Repository<Estado>,IEstadoRepository 
    {
        public EstadoRepository(VirtusContext context) : base(context)
        {
        }
    }
}