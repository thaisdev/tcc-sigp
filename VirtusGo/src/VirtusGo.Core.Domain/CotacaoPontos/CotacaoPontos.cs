using System;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.CotacaoPontos
{
    public class CotacaoPontos : Entity<CotacaoPontos>
    {
        public CotacaoPontos(int id, double valor, DateTime dataVigencia, FlagExcluidoEnum flagExcluido,
            DateTime dataCriacao, DateTime? dataAlteracao, int usuarioIdCriacao, int? usuarioIdAltera)
        {
            Id = id;
            Valor = valor;
            DataVigencia = dataVigencia;
            FlagExcluido = flagExcluido;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            UsuarioIdCriacao = usuarioIdCriacao;
            UsuarioIdAltera = usuarioIdAltera;
        }

        private CotacaoPontos()
        {
        }

        public double Valor { get; set; }
        public DateTime DataVigencia { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int UsuarioIdCriacao { get; set; }
        public int? UsuarioIdAltera { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        public static class CotacaoFactory
        {
            public static CotacaoPontos CotacaoPontosCompleto(int id, double valor, DateTime dataVigencia,
                FlagExcluidoEnum flagExcluido, DateTime dataCriacao, DateTime? dataAlteracao, int usuarioIdCriacao,
                int? usuarioIdAlteracao)
            {
                var cotacao = new CotacaoPontos()
                {
                    Id = id,
                    Valor = valor,
                    DataVigencia = dataVigencia,
                    FlagExcluido = flagExcluido,
                    DataCriacao = dataCriacao,
                    DataAlteracao = dataAlteracao,
                    UsuarioIdCriacao = usuarioIdCriacao,
                    UsuarioIdAltera = usuarioIdAlteracao
                };

                return cotacao;
            }
        }

        #region Validações

        private void Validar()
        {
            ValidarValor();
            ValidationResult = Validate(this);
        }

        private void ValidarValor()
        {
            RuleFor(x => x.Valor)
                .NotEmpty().WithMessage("Valor precisa ser fornecido");
        }

        #endregion
    }
}