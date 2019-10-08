namespace VirtusGo.Core.Domain.Pedido.Commands
{
    public class ExcluirPedidoCommand : BasePedidoCommand
    {
        public ExcluirPedidoCommand(int id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
