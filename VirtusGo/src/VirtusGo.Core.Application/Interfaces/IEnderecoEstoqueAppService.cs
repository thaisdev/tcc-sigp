using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IEnderecoEstoqueAppService : IDisposable
    {
        void Adicionar(EnderecoEstoqueViewModel enderecoEstoqueViewModel);
        void Atualizar(EnderecoEstoqueViewModel enderecoEstoqueViewModel);
        void Excluir(int id);
    }
}