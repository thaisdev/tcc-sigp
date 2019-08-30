using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IEmpresaAppService : IDisposable
    {
        EmpresaViewModel ObterPorCnpj(string cnpj);
        EmpresaViewModel Adicionar(EmpresaViewModel empresaViewModel);
        EmpresaViewModel Atualizar(EmpresaViewModel empresaViewModel);
        EmpresaViewModel ObterPorEmpresaId(int id);
        IEnumerable<EmpresaViewModel> ObterTodosQueryable();
        IEnumerable<EmpresaViewModel> ObterTodosAtivos();
        List<EmpresaViewModel> ObterTodosInativos();
        EmpresaViewModel Remover(int id);
        EmpresaViewModel Desativar(EmpresaViewModel empresaViewModel);
        EmpresaViewModel Reativar(EmpresaViewModel empresaViewModel);
        List<int> ObterEmpresasIdPorUsuario(int id);
    }
}