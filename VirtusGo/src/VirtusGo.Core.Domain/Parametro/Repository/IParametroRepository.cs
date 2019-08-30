using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Parametro.Repository
{
    public interface IParametroRepository : IRepository<Parametro>
    {
        List<Parametro> ObterTodosQueriable();
        List<Parametro> ObterTodosAtivo();
        Parametro ObterParametroAtivo();
    }
}