using System;
using VirtusGo.Core.Application.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class RotaAppService : IRotaAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}