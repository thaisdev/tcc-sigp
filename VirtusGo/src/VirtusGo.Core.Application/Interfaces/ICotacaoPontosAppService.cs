using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface ICotacaoPontosAppService : IDisposable
    {
        List<CotacaoPontosViewModel> ObterTodosQueriable();
        CotacaoPontosViewModel Adicionar(CotacaoPontosViewModel cotacao);
        CotacaoPontosViewModel Atualizar(CotacaoPontosViewModel cotacao);
        CotacaoPontosViewModel ObterPorCotacaoId(int id);
        void Excluir(int id);
        CotacaoPontosViewModel Desativar(int id);
    }
}