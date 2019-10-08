using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        void Adicionar(ProdutoViewModel produtoViewModel);
        void Atualizar(ProdutoViewModel produtoViewModel);
        void Excluir(int id);
    }
}