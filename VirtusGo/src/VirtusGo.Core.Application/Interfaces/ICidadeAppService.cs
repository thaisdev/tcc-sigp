using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface ICidadeAppService : IDisposable
    {
        void Adicionar(CidadeViewModel cidadeViewModel);
        void Atualizar(CidadeViewModel cidadeViewModel);
        void Excluir(int id);
        IEnumerable<CidadeViewModel> ObterTodos();
        IEnumerable<CidadeViewModel> ObterTodosQueriable();
    }
}