namespace VirtusGo.Core.Domain.Cidade.Commands
{
    public class RegistrarCidadeCommand : BaseCidadeCommand
    {
        public RegistrarCidadeCommand(int id, string nomeCidade, int estadoId)
        {
            Id = id;
            NomeCidade = nomeCidade;
            EstadoId = estadoId;

            AggregateId = id;
        }
    }
}