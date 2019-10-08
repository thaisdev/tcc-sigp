using System;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}