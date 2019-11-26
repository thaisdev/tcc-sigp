using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IOrdemCargaAppService : IDisposable
    {
        void Adicionar(OrdemCargaViewModel ordemCargaViewModel);
        void Atualizar(OrdemCargaViewModel ordemCargaViewModel);
        void Excluir(int id);
        IEnumerable<OrdemCargaViewModel> ObterTodos();
        IEnumerable<OrdemCargaViewModel> ObterTodosQueriable();
    }
}