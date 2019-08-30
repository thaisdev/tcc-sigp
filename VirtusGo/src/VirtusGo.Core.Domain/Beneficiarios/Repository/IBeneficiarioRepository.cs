using System.Collections.Generic;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Beneficiarios.Repository
{
    public interface IBeneficiarioRepository : IRepository<VirtusGo.Core.Domain.Beneficiarios.Beneficiario>
    {
        VirtusGo.Core.Domain.Beneficiarios.Beneficiario ObterPorCpf(string cpf);
        VirtusGo.Core.Domain.Beneficiarios.Beneficiario ObterPorBeneficiarioId(int id);
        VirtusGo.Core.Domain.Beneficiarios.Beneficiario ObterPorEmail(string email);
        List<VirtusGo.Core.Domain.Beneficiarios.Beneficiario> ObterTodosAtivos();
        List<VirtusGo.Core.Domain.Beneficiarios.Beneficiario> ObterTodosInativos();
        List<VirtusGo.Core.Domain.Beneficiarios.Beneficiario> ObterTodosQueriable();
        IEnumerable<VirtusGo.Core.Domain.Beneficiarios.Beneficiario> ObterTodosAtivosSelect();
    }
}