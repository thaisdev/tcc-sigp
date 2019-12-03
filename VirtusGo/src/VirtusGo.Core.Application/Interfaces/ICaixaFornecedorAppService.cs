using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface ICaixaFornecedorAppService : IDisposable
    {
        void Adicionar(CaixaFornecedorViewModel caixaFornecedorViewModel);
        void Atualizar(CaixaFornecedorViewModel caixaFornecedorViewModel);
        void Excluir(int id);
    }
}
