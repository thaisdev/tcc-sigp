using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IEstadoAppService : IDisposable
    {
        void Adicionar(EstadoViewModel estadoViewModel);
        void Atualizar(EstadoViewModel estadoViewModel);
        void Excluir(int id);
        IEnumerable<EstadoViewModel> ObterTodos();
    }
}