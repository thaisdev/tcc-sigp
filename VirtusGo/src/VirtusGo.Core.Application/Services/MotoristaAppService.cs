using System;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Services
{
    public class MotoristaAppService : IMotoristaAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(MotoristaViewModel motoristaViewModel)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(MotoristaViewModel motoristaViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}