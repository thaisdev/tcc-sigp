using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IParceiroAppService : IDisposable
    {
        void Adicionar(ParceiroViewModel parceiroViewModel);
        void Atualizar(ParceiroViewModel parceiroViewModel);
        void Excluir(int id);
        IEnumerable<ParceiroViewModel> ObterTodos();
    }
}