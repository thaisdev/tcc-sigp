using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.Produtos
{
    public class Produto : Entity<Produto>
    {
        public Produto(
            int id,
            string descricao,
            string unidade,
            int valorUnitario,
            int estoque,
            string ncm
            )
        {
            Id = id;
            Descricao = descricao;
            Unidade = unidade;
            ValorUnitario = valorUnitario;
            Estoque = estoque;
            NCM = ncm;
        }
        private Produto() { }

        public string Descricao { get; private set; }
        public string Unidade { get; private set; }
        public int ValorUnitario { get; private set; }
        public int Estoque { get; private set; }
        public string NCM { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarDescricao();
            ValidarNCM();
            ValidarUnidade();
            ValidarValorUnitario();
            ValidarEstoque();

            ValidationResult = Validate(this);
        }
        private void ValidarDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória")
                .Length(2, 20).WithMessage("É necessário ter de 2 a 20 carácteres");
        }
        private void ValidarNCM()
        {
            RuleFor(c => c.NCM)
                .NotEmpty().WithMessage("O código NCM é obrigatório")
                .Length(2, 20).WithMessage("É necessário ter de 2 a 20 carácteres");
        }
        private void ValidarUnidade()
        {
            RuleFor(c => c.Unidade)
                .NotEmpty().WithMessage("A Unidade é obrigatória")
                .Length(2, 20).WithMessage("É necessário ter de 2 a 20 carácteres");
        }
        private void ValidarValorUnitario()
        {
            RuleFor(c => c.ValorUnitario)
                .NotEmpty().WithMessage("O valor unitário é obrigatório");
        }
        private void ValidarEstoque()
        {
            RuleFor(c => c.Estoque)
                .NotEmpty().WithMessage("O estoque é obrigatório");
        }
        #endregion

        public static class ProdutoFactory
        {
            public static Produto ProdutoCompleto(
            int id,
            string descricao,
            string unidade,
            int valorUnitario,
            int estoque,
            string ncm
            )
            {
                var produto = new Produto()
                {
                    Id = id,
                    Descricao = descricao,
                    Unidade = unidade,
                    ValorUnitario = valorUnitario,
                    Estoque = estoque,
                    NCM = ncm
                };

                return produto;
            }
        }
    }
}
