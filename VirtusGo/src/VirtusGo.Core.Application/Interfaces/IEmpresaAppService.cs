using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IEmpresaAppService : IDisposable
    {
        void Adicionar(EmpresaViewModel empresaViewModel);
        void Atualizar(EmpresaViewModel empresaViewModel);
        void Excluir(int id);
    }
}