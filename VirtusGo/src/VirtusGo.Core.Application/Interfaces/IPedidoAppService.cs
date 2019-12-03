using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IPedidoAppService : IDisposable
    {
        void Adicionar(PedidoViewModel pedidoViewModel);
        void Atualizar(PedidoViewModel pedidoViewModel);
        void Excluir(int id);

        IEnumerable<PedidoViewModel> ObterTodos();
        IEnumerable<PedidoViewModel> ObterTodosQueriable();
    }
}