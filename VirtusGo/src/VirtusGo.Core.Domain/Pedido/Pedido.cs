using System;
using System.Collections.Generic;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Motoristas;

namespace VirtusGo.Core.Domain.Pedido
{
    public class Pedido : Entity<Pedido>
    {
        public Pedido(
            int id,
            int parceiroId,
            int vendedorCompradorId,
            int empresaId,
            int motoristaId,
            int usuarioId,
            DateTime dataNegociacaoPedido,
            string tipoPedido)
        {
            Id = id;
            ParceiroId = parceiroId;
            VendedorCompradorId = vendedorCompradorId;
            EmpresaId = empresaId;
            MotoristaId = motoristaId;
            UsuarioId = usuarioId;
            DataNegociacaoPedido = dataNegociacaoPedido;
            TipoPedido = tipoPedido;
        }

        private Pedido() { }

        public int ParceiroId { get; private set; }
        public int VendedorCompradorId { get; private set; }
        public int EmpresaId { get; private set; }
        public int MotoristaId { get; private set; }
        public int UsuarioId { get; private set; }
        public DateTime DataNegociacaoPedido { get; private set; }
        public string TipoPedido { get; private set; }
        
        public ICollection<ItemOrdemCarga.ItemOrdemCarga> ItensOrdemCarga { get; set; }
        
        //EF navigation
        public Parceiro.Parceiro Parceiro { get; set; }
        public Empresa.Empresa Empresa { get; set; }
        public Motorista Motorista { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarDataNegociacaoPedido();
            ValidarTipoPedido();

            ValidationResult = Validate(this);
        }
        private void ValidarDataNegociacaoPedido()
        {
            RuleFor(c => c.DataNegociacaoPedido)
                .NotEmpty().WithMessage("A data de negociação é obrigatória");
        }
        private void ValidarTipoPedido()
        {
            RuleFor(c => c.TipoPedido)
                .NotEmpty().WithMessage("O tipo de pedido é obrigatório");
        }
        #endregion

        public static class PedidoFactory
        {
            public static Pedido PedidoCompleto(
            int id,
            int parceiroId,
            int vendedorCompradorId,
            int empresaId,
            int motoristaId,
            int usuarioId,
            DateTime dataNegociacaoPedido,
            string tipoPedido)
            {
                var pedido = new Pedido()
                {
                    Id = id,
                    ParceiroId = parceiroId,
                    VendedorCompradorId = vendedorCompradorId,
                    EmpresaId = empresaId,
                    MotoristaId = motoristaId,
                    UsuarioId = usuarioId,
                    DataNegociacaoPedido = dataNegociacaoPedido,
                    TipoPedido = tipoPedido,
                };

                return pedido;
            }

        }
    }
}
