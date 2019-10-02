namespace VirtusGo.Core.Domain.ItemOrdemCarga
{
    public class RegistrarItemOrdemCargaCommand : BaseItemOrdemCargaCommand
    {
        public RegistrarItemOrdemCargaCommand(int id, int ordemCargaId, int pedidoId, int sequencia)
        {
            Id = id;
            OrdemCargaId = ordemCargaId;
            PedidoId = pedidoId;
            Sequencia = sequencia;

            AggregateId = Id;
        }
    }
}