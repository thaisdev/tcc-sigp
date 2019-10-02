namespace VirtusGo.Core.Domain.ItemOrdemCarga
{
    public class AtualizarItemOrdemCargaCommand : BaseItemOrdemCargaCommand
    {
        public AtualizarItemOrdemCargaCommand(int id, int ordemCargaId, int pedidoId, int sequencia)
        {
            Id = id;
            OrdemCargaId = ordemCargaId;
            PedidoId = pedidoId;
            Sequencia = sequencia;
        }
    }
}