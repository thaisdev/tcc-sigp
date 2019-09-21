using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.Estado.Commands
{
    public class BaseEstadoCommand : Command
    {
        public int Id { get; protected set; }
        public string NomeEstado { get; protected set; }
        public string SiglaEstado { get; protected set; }
    }
}