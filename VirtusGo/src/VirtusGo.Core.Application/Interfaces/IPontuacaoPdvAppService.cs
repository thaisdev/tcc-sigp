using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IPontuacaoPdvAppService : IDisposable
    {
        List<PontuacaoPdvViewModel> ObterTodosQueriable();
        PontuacaoPdvViewModel Excluir(int id);
        List<PontuacaoPdvViewModel> ObterTodosAtivos();
        List<PontuacaoPdvViewModel> ObterTodosAtivosPorUnidadeId(int id);
        PontuacaoPdvViewModel ObterPontuacaoPdvPorId(int id);
        void AprovarPorId(int id);
    }
}