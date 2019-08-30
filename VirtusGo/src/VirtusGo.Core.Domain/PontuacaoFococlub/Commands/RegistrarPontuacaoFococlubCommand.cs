using System;

namespace VirtusGo.Core.Domain.PontuacaoFocoClub.Commands
{
    public class RegistrarPontuacaoFococlubCommand : BasePontuacaoFocoClubCommand
    {
        public RegistrarPontuacaoFococlubCommand(int id, string email, double valor, int beneficiarioId, int pontuacaoIdGo,
            int empresaId, int? unidadeId, DateTime dataCompra, DateTime datalancamento, DateTime dataInterface)
        {
            Id = id;
            Email = email;
            ValorPontos = valor;
            BeneficiarioId = beneficiarioId;
            PontuacaoIdGo = pontuacaoIdGo;
            EmpresaId = empresaId;
            UnidadeId = unidadeId;
            DataCompra = dataCompra;
            Datalancamento = datalancamento;
            DataInterface = dataInterface;
        }
    }
}