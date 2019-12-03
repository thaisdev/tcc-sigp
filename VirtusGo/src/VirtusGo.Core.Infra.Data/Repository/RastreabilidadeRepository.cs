using VirtusGo.Core.Domain.Rastreabilidade;
using VirtusGo.Core.Domain.Rastreabilidade.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class RastreabilidadeRepository : Repository<Rastreabilidade>, IRastreabilidadeRepository
    {
        public RastreabilidadeRepository(VirtusContext context) : base(context)
        {
        }
    }
}