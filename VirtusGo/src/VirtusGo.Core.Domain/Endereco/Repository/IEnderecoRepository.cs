using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Endereco.Repository
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        IEnumerable<Endereco> ObterTodosQueriable();
    }
}