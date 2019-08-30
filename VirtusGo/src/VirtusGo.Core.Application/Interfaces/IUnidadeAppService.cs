using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IUnidadeAppService : IDisposable
    {
        UnidadeViewModel ObterPorCnpj(string cnpj);
        List<UnidadeViewModel> ObterTodosQueriable();
        List<UnidadeViewModel> ObterTodosAtivos();
        List<UnidadeViewModel> ObterTodosInativos();
        UnidadeViewModel ObterPorUnidadeId(int id);
        UnidadeViewModel Adicionar(UnidadeViewModel unidadesViewModel);
        UnidadeViewModel ObterPorEmail(string email);
        UnidadeViewModel Atualizar(UnidadeViewModel unidadesViewModel);
        void Remover(int id);
        UnidadeViewModel Desativar(int id);
        UnidadeViewModel Reativar(int id);
        List<UnidadeViewModel> ObterTodosAtivosPorEmpresa(int id);
        IEnumerable<UnidadeViewModel> ObterTodosInativosPorEmpresa(int empresaId);
    }
}