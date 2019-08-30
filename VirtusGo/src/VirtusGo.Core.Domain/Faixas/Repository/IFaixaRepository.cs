using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Faixas.Repository
{
    public interface IFaixaRepository : IRepository<Faixa>
    {
        List<Faixa> ObterTodosQueriable();
        IEnumerable<Faixa> ObterTodosAtivos();
        Faixa ObterPorFaixaId(int id);
        IEnumerable<Faixa> ObterTodosAtivosPorEmpresaId(int id);
    }
}