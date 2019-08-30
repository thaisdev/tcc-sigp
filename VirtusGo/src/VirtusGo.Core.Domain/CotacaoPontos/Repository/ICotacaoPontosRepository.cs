using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.CotacaoPontos.Repository
{
    public interface ICotacaoPontosRepository : IRepository<CotacaoPontos>
    {
        CotacaoPontos ObterPorCotacaoId(int id);
        List<CotacaoPontos> ObterTodosQueriable();
    }
}