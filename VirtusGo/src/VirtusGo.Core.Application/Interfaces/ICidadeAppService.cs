using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface ICidadeAppService : IDisposable
    {
        void Adicionar(CidadeViewModel cidadeViewModel);
    }
}