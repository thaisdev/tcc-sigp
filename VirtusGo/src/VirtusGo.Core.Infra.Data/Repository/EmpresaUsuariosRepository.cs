using VirtusGo.Core.Domain.Empresa.Repository;
using VirtusGo.Core.Domain.EmpresaUsuarios;
using VirtusGo.Core.Domain.EmpresaUsuarios.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class EmpresaUsuariosRepository : Repository<EmpresaUsuarios>, IEmpresaUsuarioRepository
    {
        public EmpresaUsuariosRepository(VirtusContext context) : base(context)
        {
        }
    }
}