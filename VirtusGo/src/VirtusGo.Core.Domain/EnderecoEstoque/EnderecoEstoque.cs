using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.EnderecoEstoque
{
    public class EnderecoEstoque : Entity<EnderecoEstoque>
    {
        public EnderecoEstoque(
            int id,
            string descricaoEndereco,
            string rua,
            string coluna)
        {
            Id = id;
            DescricaoEndereco = descricaoEndereco;
            Rua = rua;
            Coluna = coluna;
        }
        private EnderecoEstoque() { }

        public string DescricaoEndereco { get; private set; }
        public string Rua { get; private set; }
        public string Coluna { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarRua();
            ValidarColuna();

            ValidationResult = Validate(this);
        }

        private void ValidarRua()
        {
            RuleFor(c => c.Rua)
                .NotEmpty().WithMessage("A rua é obrigatóiria")
                .Length(2, 40).WithMessage("É necessário pelo menos 2 carácteres");
        }

        private void ValidarColuna()
        {
            RuleFor(c => c.Coluna)
                .NotEmpty().WithMessage("A coluna é obrigatóiria")
                .Length(2, 40).WithMessage("É necessário pelo menos 2 carácteres");
        }
        #endregion

        public static class EnderecoEstoqueFactory
        {
            public static EnderecoEstoque EnderecoEstoqueCompleto(
            int id,
            string descricaoEndereco,
            string rua,
            string coluna)
            {
                var enderecoEstoque = new EnderecoEstoque()
                {
                    Id = id,
                    DescricaoEndereco = descricaoEndereco,
                    Rua = rua,
                    Coluna = coluna,
                };
                return enderecoEstoque;
            }
        }
    }
}
