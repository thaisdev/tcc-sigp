using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.ItemOrdemCarga
{
    public class BaseItemOrdemCargaCommand : Command
    {
        public int Id { get; protected set; }
        public int PedidoId { get; protected set; }
        public int Sequencia { get; protected set; }
    }
}