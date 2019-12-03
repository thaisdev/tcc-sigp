using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Cidade;
using VirtusGo.Core.Domain.Cidade.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(VirtusContext context) : base(context)
        {
        }

        public IEnumerable<Cidade> ObterTodosQueriable()
        {
            return Db.Cidades.AsNoTracking().Include(x => x.Estado).ToList();
        }
    }
}