using System;

namespace VirtusGo.Core.Domain.Pedido.Commands
{
    public class AtualizarPedidoCommand : BasePedidoCommand
    {
        public AtualizarPedidoCommand(
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

            AggregateId = Id;
        }
    }
}
