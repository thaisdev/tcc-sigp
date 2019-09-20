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
    }
}