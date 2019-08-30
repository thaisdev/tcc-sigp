using System;
using System.Data;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Parametro
{
    public class Parametro : Entity<Parametro>
    {
        public Parametro(int id, int diasParaExpiracaoPontos, double valorComissaoGeral, FlagExcluidoEnum flagExcluido,
            DateTime dataCriacao, DateTime? dataAlteracao, int usuarioIdCriacao, int? usuarioIdAlteracao)
        {
            DiasParaExpiracaoPontos = diasParaExpiracaoPontos;
            ValorComissaoGeral = valorComissaoGeral;
            FlagExcluido = flagExcluido;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            UsuarioIdCriacao = usuarioIdCriacao;
            UsuarioIdAlteracao = usuarioIdAlteracao;
        }

        private Parametro(){}

        public int DiasParaExpiracaoPontos { get; private set; }
        public double ValorComissaoGeral { get; private set; }
        public FlagExcluidoEnum FlagExcluido { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public int UsuarioIdCriacao { get; private set; }

        public int? UsuarioIdAlteracao { get; private set; }
//          public virtual Usuario Usuario { get; set; }

        //Porcentagem geral para os pontos.
        //Este valor será utilizado quando não existir "porcentagem de ponto" para determinado valor no cadastro de Faixa.
        public double? ValorPorcentagemGeralPontosFaixa { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        #region Validações

        private void Validar()
        {
            ValidarPorcentagemPontos();
            ValidarComissaoGeral();
            ValidarDiasExpiracao();
            ValidationResult = Validate(this);
        }

        private void ValidarPorcentagemPontos()
        {
            RuleFor(x => x.ValorPorcentagemGeralPontosFaixa).NotEmpty()
                .WithMessage("Porcentagem geral de Pontos não pode ser vazio");

            RuleFor(x => x.ValorPorcentagemGeralPontosFaixa).LessThanOrEqualTo(100)
                .WithMessage("Porcentagem geral de Pontos não pode ser maior que 100");
        }

        private void ValidarComissaoGeral()
        {
            RuleFor(x => x.ValorComissaoGeral).NotEmpty().WithMessage("Comissão Geral não pode ser vazio");

            RuleFor(x => x.ValorComissaoGeral).LessThanOrEqualTo(100)
                .WithMessage("Comissão Geral não pode ser maior que 100");
        }

        private void ValidarDiasExpiracao()
        {
            RuleFor(x => x.DiasParaExpiracaoPontos).NotEmpty().WithMessage("Dias para expiração não pode ser vazio");
        }

        #endregion

        public class ParametroFactory
        {
            public static Parametro ParametroCompeleto(int id, int diasParaExpiracaoPontos, double valorComissaoGeral, double? valorPorcentagemGeralPontosFaixa,
                FlagExcluidoEnum flagExcluido,
                DateTime dataCriacao, DateTime? dataAlteracao, int usuarioIdCriacao,int? usuarioIdAlteracao)
            {
                var parametro = new Parametro()
                {
                    Id = id,
                    DiasParaExpiracaoPontos = diasParaExpiracaoPontos,
                    ValorComissaoGeral = valorComissaoGeral,
                    ValorPorcentagemGeralPontosFaixa = valorPorcentagemGeralPontosFaixa,
                    FlagExcluido = flagExcluido,
                    DataCriacao = dataCriacao,
                    DataAlteracao = dataAlteracao,
                    UsuarioIdCriacao = usuarioIdCriacao,
                    UsuarioIdAlteracao = usuarioIdAlteracao
                };

                return parametro;
            }
        }
    }
}