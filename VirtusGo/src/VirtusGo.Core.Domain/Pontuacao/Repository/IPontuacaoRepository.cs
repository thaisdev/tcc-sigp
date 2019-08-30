using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Pontuacao.Repository
{
    public interface IPontuacaoRepository : IRepository<Pontuacao>
    {
        IEnumerable<Pontuacao> ObterTodosAtivos();
        List<Pontuacao> ObterTodosInativos();
        List<Pontuacao> ObterTodosAtivosPorBeneficiarioId(int id);
        List<Pontuacao> ObterTodosAtivosPorEmpresaId(int id);
        Pontuacao ObterDadosPorId(int id);
    }
}