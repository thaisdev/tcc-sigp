using System;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.PontuacaoFococlub
{
    public class PontuacaoFocoClub : Entity<PontuacaoFocoClub>
    {
        public PontuacaoFocoClub(int id, string email, double valor, int beneficiarioId, int pontuacaoIdGo,
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

        public PontuacaoFocoClub()
        {
        }

        public string Email { get; private set; }
        public double ValorPontos { get; private set; }
        public int BeneficiarioId { get; private set; }
        public int PontuacaoIdGo { get; private set; }
        public int EmpresaId { get; private set; }
        public int? UnidadeId { get; private set; }
        public DateTime DataCompra { get; private set; }
        public DateTime Datalancamento { get; private set; }
        public DateTime DataInterface { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }


        #region Validações

        private void Validar()
        {
            ValidarEmail();
            ValidarBeneficiarioId();
            ValidarEmpresaId();
            ValidarDataLancamento();
            ValdiarDataInterface();
            ValidationResult = Validate(this);
        }

        private void ValidarEmail()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email precisa ser informado");
        }

        private void ValidarBeneficiarioId()
        {
            RuleFor(x => x.BeneficiarioId).NotEmpty().WithMessage("Chave do beneficiário precisa ser informada");
        }

        private void ValidarEmpresaId()
        {
            RuleFor(x => x.EmpresaId).NotEmpty().WithMessage("Chave da empresa precisa ser informada");
        }

        private void ValidarDataLancamento()
        {
            RuleFor(x => x.Datalancamento).NotEmpty().WithMessage("Data de lançamento precisa ser informada");
        }

        private void ValdiarDataInterface()
        {
            RuleFor(x => x.DataInterface).NotEmpty().WithMessage("Data interface precisa ser informada");
        }

        #endregion

        public static class PontuacaoFococlubFactory
        {
            public static PontuacaoFocoClub PontuacaoCompleto(int id, string email, double valor, int beneficiarioId,
                int pontuacaoIdGo,
                int empresaId, int? unidadeId, DateTime dataCompra, DateTime datalancamento, DateTime dataInterface)
            {
                var pontuacaoFococlub = new PontuacaoFocoClub()
                {
                    Id = id,
                    Email = email,
                    ValorPontos = valor,
                    BeneficiarioId = beneficiarioId,
                    PontuacaoIdGo = pontuacaoIdGo,
                    EmpresaId = empresaId,
                    UnidadeId = unidadeId,
                    DataCompra = dataCompra,
                    Datalancamento = datalancamento,
                    DataInterface = dataInterface,
                };
                return pontuacaoFococlub;
            }
        }
    }
}