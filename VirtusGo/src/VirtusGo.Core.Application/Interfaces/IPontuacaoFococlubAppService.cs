using System;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IPontuacaoFococlubAppService : IDisposable
    {
        //CRUD
        PontuacaoFococlubViewModel Adicionar(PontuacaoFococlubViewModel pontuacaoFococlubViewModel);
        PontuacaoFococlubViewModel Atualizar(PontuacaoFococlubViewModel pontuacaoFococlubViewModel);
    }
}