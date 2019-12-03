using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IMotoristaAppService : IDisposable
    {
        void Adicionar(MotoristaViewModel motoristaViewModel);
        void Atualizar(MotoristaViewModel motoristaViewModel);
        void Excluir(int id);
        IEnumerable<MotoristaViewModel> ObterTodosQueriable();
        IEnumerable<MotoristaViewModel> ObterTodos();
    }
}