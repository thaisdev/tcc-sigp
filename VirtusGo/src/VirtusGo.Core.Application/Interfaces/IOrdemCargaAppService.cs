using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IOrdemCargaAppService : IDisposable
    {
        void Adicionar(OrdemCargaViewModel ordemCargaViewModel);
    }
}