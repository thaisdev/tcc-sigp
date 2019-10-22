using System.Collections;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.CondicaoFinanceira
{
    public class CondicaoFinanceira : Entity<CondicaoFinanceira>
    {
        public CondicaoFinanceira(int id, int parcelas, int dias)
        {
            Id = id;
            Parcelas = parcelas;
            Dias = dias;
        }

        public CondicaoFinanceira()
        {
        }

        public int Parcelas { get; private set; }

        public int Dias { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarParcelas();
            ValidarDias();
        }

        private void ValidarParcelas()
        {
            RuleFor(x => x.Parcelas).NotEmpty().WithMessage("Número de parcelas não pode ser vazio");
        }

        private void ValidarDias()
        {
            RuleFor(x => x.Dias).NotEmpty().WithMessage("Quantidade de dias nçao pode ser vazio");
        }

        #endregion

        public static class CondicaoFinanceiraFactory
        {
            public static CondicaoFinanceira CondicaoFinanceiraCompleto(int id, int parcelas, int dias)
            {
                var condicaofinanceira = new CondicaoFinanceira()
                {
                    Id = id,
                    Parcelas = parcelas,
                    Dias = dias
                };
                return condicaofinanceira;
            }
        }
    }
}