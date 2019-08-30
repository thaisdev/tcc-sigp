using System;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Faixas
{
    public sealed class Faixa : Entity<Faixa>
    {
        private Faixa(int id, double valorDe, double valorAte, double valorPorcentagem, FlagExcluidoEnum flagExcluido,
            DateTime dataCriacao, DateTime? dataAlteracao, int empresaId, int? unidadeId, int usuarioIdCriacao,
            int? usuarioIdAltera)
        {
            Id = id;
            ValorDe = valorDe;
            ValorAte = valorAte;
            ValorPorcentagem = valorPorcentagem;
            FlagExcluido = flagExcluido;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            EmpresaId = empresaId;
            UnidadeId = unidadeId;
            UsuarioIdCriacao = usuarioIdCriacao;
            UsuarioIdAltera = usuarioIdAltera;
        }

        private Faixa()
        {
        }

        public double ValorDe { get; private set; }
        public double ValorAte { get; private set; }
        public double ValorPorcentagem { get; private set; }
        public FlagExcluidoEnum FlagExcluido { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public int EmpresaId { get; private set; }
        public Empresas Empresa { get; set; }
        public int? UnidadeId { get; private set; }
        public Unidades.Unidade Unidades { get; set; }

        public int UsuarioIdCriacao { get; set; }

        //public virtual Usuario Usuario { get; set; }
        public int? UsuarioIdAltera { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarEmpresaId();
            ValidarPorcentagem();
            ValidarValor();
            ValidarDeAte();
            ValidationResult = Validate(this);
        }

        private void ValidarValor()
        {
            RuleFor(x => x.ValorDe)
                .NotEmpty().WithMessage("Valor De precisa ser informado");

            RuleFor(x => x.ValorAte)
                .NotEmpty().WithMessage("Valor Até precisa ser informado");
        }

        private void ValidarDeAte()
        {
            RuleFor(x => x.ValorAte)
                .GreaterThan(x => x.ValorDe)
                .WithMessage("Valor De precisa ser menor que o Valor Até");
        }

        private void ValidarPorcentagem()
        {
            RuleFor(x => x.ValorPorcentagem)
                .NotEmpty().WithMessage("Valor da porcentagem precisa ser informado");
        }

        private void ValidarEmpresaId()
        {
            RuleFor(x => x.EmpresaId)
                .NotEmpty().WithMessage("Nome da empresa precisa ser informado");
        }

        #endregion

        public static class FaixaFactory
        {
            public static Faixa FaixaCompleta(int id, double valorDe, double valorAte, double
                valorPorcentagem, FlagExcluidoEnum flagExcluido, DateTime dataCriacao, DateTime? dataAlteracao, int
                empresaId, int? unidadeId, int usuarioIdCriacao, int? usuarioIdAltera)
            {
                var faixa = new Faixa()
                {
                    Id = id,
                    ValorDe = valorDe,
                    ValorAte = valorAte,
                    ValorPorcentagem = valorPorcentagem,
                    FlagExcluido = flagExcluido,
                    DataCriacao = dataCriacao,
                    DataAlteracao = dataAlteracao,
                    EmpresaId = empresaId,
                    UnidadeId = unidadeId,
                    UsuarioIdCriacao = usuarioIdCriacao,
                    UsuarioIdAltera = usuarioIdAltera
                };

                return faixa;
            }
        }
    }
}