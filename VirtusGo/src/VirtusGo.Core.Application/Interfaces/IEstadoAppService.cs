using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IEstadoAppService : IDisposable
    {
        void Adicionar(EstadoViewModel estadoViewModel);
    }
}