using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.Veiculo.Commands
{
    public class BaseVeiculoCommand : Command
    {
        public int Id { get; protected set; }
        public string Placa { get; protected set; }
        public string Modelo { get; protected set; }
        public string Cor { get; protected set; }
        public string Marca { get; protected set; }
        public string Renavam { get; protected set; }
    }
}