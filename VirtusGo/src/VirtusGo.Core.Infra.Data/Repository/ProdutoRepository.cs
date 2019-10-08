using VirtusGo.Core.Domain.Produtos;
using VirtusGo.Core.Domain.Produtos.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(VirtusContext context) : base(context)
        {
        }
    }
}