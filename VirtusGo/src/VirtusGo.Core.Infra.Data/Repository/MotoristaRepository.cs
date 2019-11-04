using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Motorista> ObterTodosQueriable()
        {
            return Db.Motorista.Include(x => x.Endereco).ToList();
        }
    }
}