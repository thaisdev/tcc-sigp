using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.Cidade.Commands
{
    public class BaseCidadeCommand : Command
    {
        public int Id { get; protected set; }
        public string NomeCidade { get; protected set; }
        public int EstadoId { get; protected set; }
    }
}