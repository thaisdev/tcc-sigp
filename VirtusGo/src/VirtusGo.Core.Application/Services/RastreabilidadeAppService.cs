using System;
using VirtusGo.Core.Application.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class RastreabilidadeAppService : IRastreabilidadeAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}