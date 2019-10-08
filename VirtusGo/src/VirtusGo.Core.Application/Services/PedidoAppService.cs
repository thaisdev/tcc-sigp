using System;
using VirtusGo.Core.Application.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class PedidoAppService : IPedidoAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}