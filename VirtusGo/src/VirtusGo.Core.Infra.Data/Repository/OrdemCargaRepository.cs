using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var t = Db.OrdemCarga.Include(x => x.Motorista).Include(x => x.Rota).Include(x => x.Rota.Endereco)
                .Include(x => x.Veiculo).ToList();
            return t;
        }
    }
}