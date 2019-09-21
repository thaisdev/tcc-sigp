using VirtusGo.Core.Domain.Parceiro;
using VirtusGo.Core.Domain.Parceiro.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class ParceiroRepository : Repository<Parceiro>, IParceiroRepository
    {
        public ParceiroRepository(VirtusContext context) : base(context)
        {
        }
    }
}