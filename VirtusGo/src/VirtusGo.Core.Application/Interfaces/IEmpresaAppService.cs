using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IEmpresaAppService : IDisposable
    {
        void Adicionar(EmpresasViewModel empresasViewModel);
        void Atualizar(EmpresasViewModel empresasViewModel);
        void Excluir(int id);
    }
}