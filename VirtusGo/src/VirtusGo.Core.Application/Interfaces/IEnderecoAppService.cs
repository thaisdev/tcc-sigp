using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IEnderecoAppService : IDisposable
    {
        void Adiconar(EnderecoViewModel model);
    }
}