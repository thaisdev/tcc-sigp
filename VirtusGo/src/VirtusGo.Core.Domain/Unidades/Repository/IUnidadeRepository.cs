using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Unidades.Repository
{
    public interface IUnidadeRepository : IRepository<Unidade>
    {
        Unidade ObterPorCnpj(string cnpj);
        Unidade ObterPorFantasia(string fantasia);
        Unidade ObterPorUnidadeId(int id);
        
        Unidade ObterPorEmail(string email);
        List<Unidade> ObterTodosQueryiable();
        List<Unidade> ObterTodosAtivos();
        
        List<Unidade> ObterTodosInativos();
        List<Unidade> ObterTodosAtivosPorEmpresa(int id);
        List<Unidade> ObterTodosInativosPorEmpresa(int empresaId);
    }
}