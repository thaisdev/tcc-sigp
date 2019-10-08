using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IEnderecoAppService : IDisposable
    {
        void Adicionar(EnderecoViewModel enderecoViewModel);
        void Atualizar(EnderecoViewModel enderecoViewModel);
        void Excluir(int id);
    }
}