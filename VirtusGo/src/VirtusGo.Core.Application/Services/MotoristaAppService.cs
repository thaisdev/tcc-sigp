using System;
using VirtusGo.Core.Application.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class MotoristaAppService : IMotoristaAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}