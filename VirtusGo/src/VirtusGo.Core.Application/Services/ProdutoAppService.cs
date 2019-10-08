using System;
using VirtusGo.Core.Application.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}