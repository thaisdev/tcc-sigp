using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Veiculo.Repository
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        IEnumerable<Veiculo> ObterTodosQueriable();
    }
}