using System;
using VirtusGo.Core.Application.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class ItensPedidoAppService : IItensPedidoAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}