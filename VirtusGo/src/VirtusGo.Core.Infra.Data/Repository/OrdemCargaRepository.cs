using System.Collections.Generic;
using VirtusGo.Core.Domain.OrdemCarga;
using VirtusGo.Core.Domain.OrdemCarga.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class OrdemCargaRepository : Repository<OrdemCarga>, IOrdemCargaRepository
    {
        public OrdemCargaRepository(VirtusContext context) : base(context)
        {
        }

        public IEnumerable<OrdemCarga> ObterTodosQueriable()
        {
            throw new System.NotImplementedException();
        }
    }
}