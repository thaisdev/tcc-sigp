using System;
using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Empresa.Repository
{
    public interface IEmpresaRepository : IRepository<Empresas>
    {
        Empresas ObterPorEmpresaId(int id);
        Empresas ObterPorCnpj(string cnpj);
        Empresas ObterPorRazaoSocial(string razao);
        Empresas ObterPorGuid(Guid guid);
        Empresas ObterPorEmail(string email);
        List<Empresas> ObterTodosQueriable();
        List<Empresas> ObterTodosAtivos();
        List<Empresas> ObterTodosInativos();
    }
}