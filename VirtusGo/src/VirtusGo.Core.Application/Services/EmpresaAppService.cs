using System;
using VirtusGo.Core.Application.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class EmpresaAppService : IEmpresaAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}