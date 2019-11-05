using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IVeiculoAppService : IDisposable
    {
        void Adicionar(VeiculoViewModel veiculoViewModel);
        void Atualizar(VeiculoViewModel veiculoViewModel);
        void Excluir(int id);
        IEnumerable<VeiculoViewModel> ObterTodos();
        IEnumerable<VeiculoViewModel> ObterTodosQueriable();
    }
}