using System;

namespace VirtusGo.Core.Domain.Pedido.Commands
{
    public class RegistrarPedidoCommand : BasePedidoCommand
    {
        public RegistrarPedidoCommand(
            int id,
            int parceiroId,
            int vendedorCompradorId,
            int motoristaId, int pagamentoId,
            DateTime dataNegociacaoPedido,
            string tipoPedido)
        {
            Id = id;
            ParceiroId = parceiroId;
            VendedorCompradorId = vendedorCompradorId;
            MotoristaId = motoristaId;
            PagamentoId = pagamentoId;
            DataNegociacaoPedido = dataNegociacaoPedido;
            TipoPedido = tipoPedido;

            AggregateId = Id;
        }
    }
}