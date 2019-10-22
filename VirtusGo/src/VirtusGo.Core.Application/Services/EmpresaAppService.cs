using System;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Services
{
    public class EmpresaAppService : IEmpresaAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(EmpresaViewModel empresaViewModel)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(EmpresaViewModel empresaViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}