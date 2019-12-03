using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Produtos;

namespace VirtusGo.Core.Domain.ItensPedidos
{
    public class ItensPedido : Entity<ItensPedido>
    {
        public ItensPedido(
            int id,
            int produtoId, int pedidoId,
            double valorUnitario,
            double valorTotal, int quantidade)
        {
            Id = id;
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            ValorUnitario = valorUnitario;
            ValorTotal = valorTotal;
            Quantidade = quantidade;
        }

        private ItensPedido()
        {
        }

        public int ProdutoId { get; private set; }
        public int PedidoId { get; private set; }
        public double ValorUnitario { get; private set; }
        public double ValorTotal { get; private set; }

        public int Quantidade { get; private set; }

        //EF Navigation
        public Produto Produtos { get; set; }
        public Pedido.Pedido Pedido { get; set; }

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
                int produtoId, int pedidoId,
                double valorUnitario,
                double valorTotal, int quantidade)
            {
                var itensPedido = new ItensPedido()
                {
                    Id = id,
                    ProdutoId = produtoId,
                    PedidoId = pedidoId,
                    ValorUnitario = valorUnitario,
                    ValorTotal = valorTotal,
                    Quantidade = quantidade
                };

                return itensPedido;
            }
        }
    }
}