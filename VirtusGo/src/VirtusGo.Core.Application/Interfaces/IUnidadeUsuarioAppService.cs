using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IUnidadeUsuarioAppService : IDisposable
    {
        //CRUD
        UnidadeUsuarioViewModel Adicionar(UnidadeUsuarioViewModel unidadeUsuarioViewModel);
        List<UnidadeUsuarioViewModel> ObterTodos();
    }
}
