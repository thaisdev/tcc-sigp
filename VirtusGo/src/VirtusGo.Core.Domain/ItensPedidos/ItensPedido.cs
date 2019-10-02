using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.ItensPedidos
{
    public class ItensPedido : Entity<ItensPedido>
    {
        public ItensPedido(
            int id,
            int produtoId,
            double valorUnitario,
            double valorTotal)
        {
            Id = id;
            ProdutoId = produtoId;
            ValorUnitario = valorUnitario;
            ValorTotal = valorTotal;
        }

        private ItensPedido() { }

        public int ProdutoId { get; private set; }
        public double ValorUnitario { get; private set; }
        public double ValorTotal { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarValorUnitario();
            ValidarValorTotal();

            ValidationResult = Validate(this);
        }

        private void ValidarValorUnitario()
        {
            RuleFor(c => c.ValorUnitario)
                .NotEmpty().WithMessage("O valor unitário é obrigatório");
        }

        private void ValidarValorTotal()
        {
            RuleFor(c => c.ValorTotal)
                .NotEmpty().WithMessage("O valor total é obrigatório");
        }
        #endregion

        public static class ItensPedidoFactory
        {
            public static ItensPedido ItensPedidoCompleto(
            int id,
            int produtoId,
            double valorUnitario,
            double valorTotal)
            {
                var itensPedido = new ItensPedido()
                {
                    Id = id,
                    ProdutoId = produtoId,
                    ValorUnitario = valorUnitario,
                    ValorTotal = valorTotal,
                };

                return itensPedido;
        }
    }
}
}
