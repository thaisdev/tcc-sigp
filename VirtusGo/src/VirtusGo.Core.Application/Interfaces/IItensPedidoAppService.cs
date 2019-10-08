using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IItensPedidoAppService : IDisposable
    {
        void Adicionar(ItensPedidoViewModel itensPedidoViewModel);
        void Atualizar(ItensPedidoViewModel itensPedidoViewModel);
        void Excluir(int id);
    }
}