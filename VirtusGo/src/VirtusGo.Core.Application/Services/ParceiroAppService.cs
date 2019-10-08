using System;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Services
{
    public class ParceiroAppService : IParceiroAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(ParceiroViewModel parceiroViewModel)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(ParceiroViewModel parceiroViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}