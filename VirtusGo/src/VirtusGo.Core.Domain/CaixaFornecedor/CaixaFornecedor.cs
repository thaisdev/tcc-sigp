using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.CaixaFornecedor
{
    public class CaixaFornecedor : Entity<CaixaFornecedor>
    {
        public CaixaFornecedor(
            int id,
            int parceiroId,
            DateTime data)
        {

        }
        private CaixaFornecedor() { }

        public int ParceiroId { get; private set; }
        public DateTime Data { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarParceiroId();
            ValidarData();
        }

        private void ValidarParceiroId()
        {
            RuleFor(c => c.ParceiroId)
                .NotEmpty().WithMessage("O ID de parceiro é obrigatório");
        }
        private void ValidarData()
        {
            RuleFor(c => c.Data)
                .NotEmpty().WithMessage("A data é obrigatória");

        }
        #endregion

        public static class CaixaFornecedorFactory
        {
            public static CaixaFornecedor CaixaFornecedorCompleto(
                int id,
                int parceiroId,
                DateTime data)
            {
                var caixaFornecedor = new CaixaFornecedor()
                {
                    Id = id,
                    ParceiroId = parceiroId,
                    Data = data
                };

                return caixaFornecedor;
            }
        }
    }
}
