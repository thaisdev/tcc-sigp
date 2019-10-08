using System;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.Pedido.Commands
{
    public class BasePedidoCommand : Command
    {
        public int Id { get; protected set; }
        public int ParceiroId { get; protected set; }
        public int VendedorCompradorId { get; protected set; }
        public int EmpresaId { get; protected set; }
        public int MotoristaId { get; protected set; }
        public int UsuarioId { get; protected set; }
        public DateTime DataNegociacaoPedido { get; protected set; }
        public string TipoPedido { get; protected set; }
    }
}
