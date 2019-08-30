namespace VirtusGo.Core.Domain.Unidades.Commands
{
    public class DesativarUnidadeCommand : BaseUnidadeCommand
    {
        public DesativarUnidadeCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}