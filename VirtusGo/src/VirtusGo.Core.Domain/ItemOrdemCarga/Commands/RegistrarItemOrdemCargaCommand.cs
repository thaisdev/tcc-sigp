namespace VirtusGo.Core.Domain.ItemOrdemCarga
{
    public class RegistrarItemOrdemCargaCommand : BaseItemOrdemCargaCommand
    {
        public RegistrarItemOrdemCargaCommand(int id, int pedidoId, int sequencia)
        {
            Id = id;
            PedidoId = pedidoId;
            Sequencia = sequencia;

            AggregateId = Id;
        }
    }
}