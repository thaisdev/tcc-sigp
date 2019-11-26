using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.OrdemCarga.Repository
{
    public interface IOrdemCargaRepository : IRepository<OrdemCarga>
    {
        IEnumerable<OrdemCarga> ObterTodosQueriable();
    }
}