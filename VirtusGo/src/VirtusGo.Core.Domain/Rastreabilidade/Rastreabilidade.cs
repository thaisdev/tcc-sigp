using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Produtos;

namespace VirtusGo.Core.Domain.Rastreabilidade
{
    public class Rastreabilidade : Entity<Rastreabilidade>
    {
        public Rastreabilidade(
            int pedidoVendaId,
            int pedidoCompraId,
            int produtoID,
            int quantidade)
        {
            PedidoVendaId = pedidoVendaId;
            PedidoCompraId = pedidoCompraId;
            ProdutoId = produtoID;
            Quantidade = quantidade;
        }

        private Rastreabilidade() { }

        public int PedidoVendaId { get; private set; }
        public int PedidoCompraId { get; private set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        
        //EF Navigation
        public Produto Produtos { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarPedidoVendaId();
            ValidarPedidoCompraId();
            ValidarProdutoId();
            ValidarQuantidade();

            ValidationResult = Validate(this);
        }

        private void ValidarQuantidade()
        {
            RuleFor(c => c.Quantidade)
                .NotEmpty().WithMessage("A quantidade é obrigatória");
        }

        private void ValidarProdutoId()
        {
            RuleFor(c => c.ProdutoId)
                .NotEmpty().WithMessage("O ID de produto é obrigatório");
        }

        private void ValidarPedidoCompraId()
        {
            RuleFor(c => c.PedidoCompraId)
                .NotEmpty().WithMessage("O ID de pedido de compra é obrigatório");
        }

        private void ValidarPedidoVendaId()
        {
            RuleFor(c => c.PedidoVendaId)
                .NotEmpty().WithMessage("O ID de pedido de venda é obrigatório");
        }
        #endregion

        public static class RastreabilidadeFactory
        {
            public static Rastreabilidade RastreabilidadeCompleta(
            int pedidoVendaId,
            int pedidoCompraId,
            int produtoID,
            int quantidade)
            {
                var rastreabilidade = new Rastreabilidade()
                {
                    PedidoVendaId = pedidoVendaId,
                    PedidoCompraId = pedidoCompraId,
                    ProdutoId = produtoID,
                    Quantidade = quantidade,
                };
                return rastreabilidade;
            }
        }
    }
}

