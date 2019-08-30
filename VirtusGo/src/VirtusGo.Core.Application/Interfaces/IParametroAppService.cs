using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IParametroAppService : IDisposable
    {
        ParametrosViewModel Adicionar(ParametrosViewModel parametrosViewModel);
        ParametrosViewModel Atualizar(ParametrosViewModel parametrosViewModel);
        void Remover(int id);
        List<ParametrosViewModel> ObterTodosQueriable();
        List<ParametrosViewModel> ObterTodosAtivos();
        ParametrosViewModel ObterParametroAtivo();
    }
}