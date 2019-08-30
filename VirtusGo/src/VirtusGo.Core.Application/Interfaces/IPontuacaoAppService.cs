using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IPontuacaoAppService : IDisposable
    {
        PontuacaoViewModel Adicionar(PontuacaoViewModel pontuacaoPdvViewModel);
        PontuacaoViewModel Atualizar(PontuacaoViewModel pontuacaoPdvViewModel);
        void DesativarPorId(int id);
        void Remover(int id);
        List<PontuacaoViewModel> ObterTodosAtivos();
        List<PontuacaoViewModel> ObterTodosInativos();
        List<PontuacaoViewModel> ObterTodosAtivosPorEmpresaId(int id);
        List<PontuacaoViewModel> ObterTodosAtivosPorBeneficiarioId(int id);
        PontuacaoViewModel ObterPorId(int id);
    }
}