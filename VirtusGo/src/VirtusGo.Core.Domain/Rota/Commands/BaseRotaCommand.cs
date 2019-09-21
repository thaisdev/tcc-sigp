using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.Rota.Commands
{
    public class BaseRotaCommand : Command
    {
        public int Id { get; protected set; }
        public int EnderecoId { get; protected set; }
    }
}