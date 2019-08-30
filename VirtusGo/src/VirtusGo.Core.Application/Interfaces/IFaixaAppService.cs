using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IFaixaAppService : IDisposable
    {
        FaixaViewModel Adicionar(FaixaViewModel faixa);
        FaixaViewModel Atualizar(FaixaViewModel faixaViewModel);
        void Excluir(FaixaViewModel faixaViewModel);
        List<FaixaViewModel> ObterTodosQueriable();
        IEnumerable<FaixaViewModel> ObterTodosAtivos();
        FaixaViewModel ObterPorId(int id);
        IEnumerable<FaixaViewModel> ObterTodosAtivosPorEmpresaId(int id);
    }
}