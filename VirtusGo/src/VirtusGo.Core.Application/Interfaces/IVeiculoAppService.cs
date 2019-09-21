using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IVeiculoAppService : IDisposable
    {
        void Adicionar(VeiculoViewModel veiculoViewModel);
    }
}