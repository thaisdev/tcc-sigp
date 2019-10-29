using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IVendedorCompradorAppService :IDisposable
    {
        void Adicionar(VendedorCompradorViewModel vendedorCompradorViewModel);
        void Atualizar(VendedorCompradorViewModel vendedorCompradorViewModel);
        void Excluir(int id);

    }
}
