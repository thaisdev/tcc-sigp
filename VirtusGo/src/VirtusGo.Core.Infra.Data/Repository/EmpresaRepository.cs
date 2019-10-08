using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Empresas.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(VirtusContext context) : base(context)
        {
        }
    }
}