using System;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Services
{
    public class RastreabilidadeAppService : IRastreabilidadeAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(RastreabilidadeViewModel rastreabilidadeViewModel)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(RastreabilidadeViewModel rastreabilidadeViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}