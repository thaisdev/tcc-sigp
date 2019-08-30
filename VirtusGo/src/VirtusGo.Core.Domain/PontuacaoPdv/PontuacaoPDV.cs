using System;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Unidades;

namespace VirtusGo.Core.Domain.PontuacaoPdv
{
    public class PontuacaoPDV : Entity<PontuacaoPDV>
    {
        public PontuacaoPDV(int id, double valorLancamento, DateTime dataCompra, string cpf, string operador,
            string email, FlagExcluidoEnum flagExcluido, string flagInterface, DateTime? dataInterface,
            int? usuarioIdInterface, string flagErroInterface, string mensagemErroInterface, int unidadeId,
            int empresaId)
        {
            Id = id;
            ValorLancamento = valorLancamento;
            DataCompra = dataCompra;
            Cpf = cpf;
            Operador = operador;
            Email = email;
            FlagExcluido = flagExcluido;
            FlagInterface = flagInterface;
            DataInterface = dataInterface;
            UsuarioIdInterface = usuarioIdInterface;
            FlagErroInterface = flagErroInterface;
            MensagemErroInterface = mensagemErroInterface;
            UnidadeId = unidadeId;
            EmpresaId = empresaId;
        }

        private PontuacaoPDV()
        {
        }

        public double ValorLancamento { get; set; }
        public DateTime DataCompra { get; set; }
        public string Cpf { get; set; }
        public string Operador { get; set; }
        public string Email { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public string FlagInterface { get; set; }
        public DateTime? DataInterface { get; set; }
        public int? UsuarioIdInterface { get; set; }
        public string FlagErroInterface { get; set; }
        public string MensagemErroInterface { get; set; }
        public int UnidadeId { get; set; }
        public int EmpresaId { get; set; }

        //EF proprieade de navegação
        public virtual Empresas Empresa { get; set; }

        public virtual Unidade Unidade { get; set; }

        //public virtual Usuario Usuario { get; set; }
        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }


        public static class PontuacaoPdvFactory
        {
            public static PontuacaoPDV PontuacaoPdvCompleto(int id, double valorLancamento, DateTime dataCompra,
                string cpf, string operador,
                string email, FlagExcluidoEnum flagExcluido, string flagInterface, DateTime? dataInterface,
                int? usuarioIdInterface, string flagErroInterface, string mensagemErroInterface, int unidadeId,
                int empresaId)
            {
                var pdv = new PontuacaoPDV()
                {
                    Id = id,
                    ValorLancamento = valorLancamento,
                    DataCompra = dataCompra,
                    Cpf = cpf,
                    Operador = operador,
                    Email = email,
                    FlagExcluido = flagExcluido,
                    FlagInterface = flagInterface,
                    DataInterface = dataInterface,
                    UsuarioIdInterface = usuarioIdInterface,
                    FlagErroInterface = flagErroInterface,
                    MensagemErroInterface = mensagemErroInterface,
                    UnidadeId = unidadeId,
                    EmpresaId = empresaId
                };

                return pdv;
            }
        }

        #region Validações

        private void Validar()
        {
            ValidationResult = Validate(this);
        }

        private void ValidarValorLancto()
        {
            RuleFor(x => x.ValorLancamento)
                .NotEmpty().WithMessage("Valor lançamento precisa ser informado");
        }

        private void ValidarDataCompra()
        {
            RuleFor(x => x.DataCompra)
                .NotEmpty().WithMessage("Data de compra precisa ser informado");
        }

        private void ValidarDocumento()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF precisa ser informado")
                .Length(14).WithMessage("CPF precisa ter 14 caracteres");
        }

        private void ValidarEmail()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email precisa ser informado")
                .Length(2, 60).WithMessage("Email precisa ter entre 2 e 60 caracteres");
        }

        private void ValidarEmpresaId()
        {
            RuleFor(x => x.EmpresaId)
                .NotEmpty().WithMessage("Nome da empresa precisa ser informado");
        }

        #endregion
    }
}