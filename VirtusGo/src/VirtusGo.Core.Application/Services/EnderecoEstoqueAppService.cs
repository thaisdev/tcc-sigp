using System;
using VirtusGo.Core.Application.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class EnderecoEstoqueAppService : IEnderecoEstoqueAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}