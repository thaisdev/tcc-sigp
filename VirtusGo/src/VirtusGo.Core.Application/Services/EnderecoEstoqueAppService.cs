using System;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Services
{
    public class EnderecoEstoqueAppService : IEnderecoEstoqueAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(EnderecoEstoqueViewModel enderecoEstoqueViewModel)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(EnderecoEstoqueViewModel enderecoEstoqueViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}