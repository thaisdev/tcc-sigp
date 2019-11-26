using System.Collections.Generic;
using VirtusGo.Core.Domain.CondicaoFinanceira;
using VirtusGo.Core.Domain.CondicaoFinanceira.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class CondicaoFinanceiraRepository : Repository<CondicaoFinanceira>, ICondicaoFinanceiraRepository
    {

        public CondicaoFinanceiraRepository(VirtusContext context) : base(context)
        {
            
        }

        public IEnumerable<CondicaoFinanceira> ObterTodosQueriable()
        {
            throw new System.NotImplementedException();
        }
    }
}