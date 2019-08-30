namespace VirtusGo.Core.Domain.Unidades.Commands
{
    public class ReativarUnidadeCommand : BaseUnidadeCommand
    {
        public ReativarUnidadeCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}