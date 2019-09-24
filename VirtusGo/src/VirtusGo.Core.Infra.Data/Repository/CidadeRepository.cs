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
    }
}