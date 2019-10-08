using System;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Services
{
    public class ItensPedidoAppService : IItensPedidoAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(ItensPedidoViewModel itensPedidoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(ItensPedidoViewModel itensPedidoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}