using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.PontuacaoPdv.Repository
{
    public interface IPontuacaoPDVRepository : IRepository<VirtusGo.Core.Domain.PontuacaoPdv.PontuacaoPDV>
    {
        VirtusGo.Core.Domain.PontuacaoPdv.PontuacaoPDV ObterPorPontuacaoPDVId(int id);
        List<VirtusGo.Core.Domain.PontuacaoPdv.PontuacaoPDV> ObterTodosQueriable();
        List<VirtusGo.Core.Domain.PontuacaoPdv.PontuacaoPDV> ObterTodosAtivos();
        List<VirtusGo.Core.Domain.PontuacaoPdv.PontuacaoPDV> ObterTodosAtivosPorUnidadeId(int id);
    }
}