using System;
using VirtusGo.Core.Application.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class ParceiroAppService : IParceiroAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}