using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Endereco;
using VirtusGo.Core.Domain.Endereco.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(VirtusContext context) : base(context)
        {
        }

        public IEnumerable<Endereco> ObterTodosQueriable()
        {
            return Db.Endereco.AsNoTracking().Include(x => x.Cidade).Include(x => x.Cidade.Estado).ToList();
        }
    }
}