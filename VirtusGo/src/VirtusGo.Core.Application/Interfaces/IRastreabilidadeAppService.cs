using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IRastreabilidadeAppService : IDisposable
    {
        void Adicionar(RastreabilidadeViewModel rastreabilidadeViewModel);
        void Atualizar(RastreabilidadeViewModel rastreabilidadeViewModel);
        void Excluir(int id);
    }
}