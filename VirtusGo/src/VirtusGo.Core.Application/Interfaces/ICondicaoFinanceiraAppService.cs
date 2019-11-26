using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface ICondicaoFinanceiraAppService : IDisposable
    {
        void Adicionar(CondicaoFinanceiraViewModel condicaoFinanceiraViewModel);
        
        void Atualizar(CondicaoFinanceiraViewModel condicaoFinanceiraViewModel);
        
        void Excluir(int id);

        IEnumerable<CondicaoFinanceiraViewModel> ObterTodos();
        IEnumerable<CondicaoFinanceiraViewModel> ObterTodosQueriable();

    }
}