using VirtusGo.Core.Domain.EnderecoEstoque;
using VirtusGo.Core.Domain.EnderecoEstoque.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class EnderecoEstoqueRepository : Repository<EnderecoEstoque>, IEnderecoEstoqueRepository
    {
        public EnderecoEstoqueRepository(VirtusContext context) : base(context)
        {
        }
    }
}