using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IItemOrdemCargaAppService : IDisposable
    {
        void Adicionar(ItemOrdemCargaViewModel itemOrdemCargaViewModel);
        void Atualizar(ItemOrdemCargaViewModel itemOrdemCargaViewModel);
        void Excluir(int id);
    }
}