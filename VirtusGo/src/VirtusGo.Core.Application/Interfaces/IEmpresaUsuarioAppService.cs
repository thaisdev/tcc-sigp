using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IEmpresaUsuarioAppService : IDisposable
    {
        //CRUD
        EmpresaUsuarioViewModel Adicionar(EmpresaUsuarioViewModel empresaUsuarioViewModel);
        
        IEnumerable<EmpresaUsuarioViewModel> ObterTodos();
    }
}