using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.CondicaoFinanceira.Repository
{
    public interface ICondicaoFinanceiraRepository : IRepository<CondicaoFinanceira>
    {
        IEnumerable<CondicaoFinanceira> ObterTodosQueriable();
    }
}