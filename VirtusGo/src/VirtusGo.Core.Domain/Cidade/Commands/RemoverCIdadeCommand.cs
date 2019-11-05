namespace VirtusGo.Core.Domain.Cidade.Commands
{
    public class RemoverCIdadeCommand : BaseCidadeCommand
    {
        public RemoverCIdadeCommand(int id, string nomeCidade, int estadoId)
        {
            Id = id;
            NomeCidade = nomeCidade;
            EstadoId = estadoId;
            AggregateId = Id;
        }
    }
}