using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.ViewModels;

namespace VirtusGo.Core.Application.Interfaces
{
    public interface IBeneficiarioAppService : IDisposable
    {
        BeneficiarioViewModel ObterPorCpf(string cpf);
        BeneficiarioViewModel ObterPorBeneficiarioId(int id);
        List<BeneficiarioViewModel> ObterTodosQueriable();

        BeneficiarioViewModel Adicionar(BeneficiarioViewModel beneficiarioViewModel);
        BeneficiarioViewModel ObterPorEmail(string email);
        IEnumerable<BeneficiarioViewModel> ObterTodosAtivos();
        IEnumerable<BeneficiarioViewModel> ObterTodosInativos();
        BeneficiarioViewModel Atualizar(BeneficiarioViewModel beneficiarioViewModel);
        void Remover(int id);
        BeneficiarioViewModel DesativarPorId(BeneficiarioViewModel beneficiarioViewModel);
        BeneficiarioViewModel ReativarPorId(int id);
        IEnumerable<BeneficiarioViewModel> ObterTodosAtivosSelect();
    }
}