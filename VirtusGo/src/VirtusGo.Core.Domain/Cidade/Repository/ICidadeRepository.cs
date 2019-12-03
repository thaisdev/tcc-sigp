using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Cidade.Repository
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        IEnumerable<Cidade> ObterTodosQueriable();
    }
}