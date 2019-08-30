namespace VirtusGo.Core.Domain.Unidades.Commands
{
    public class ExcluirUnidadeCommand : BaseUnidadeCommand
    {
        public ExcluirUnidadeCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}