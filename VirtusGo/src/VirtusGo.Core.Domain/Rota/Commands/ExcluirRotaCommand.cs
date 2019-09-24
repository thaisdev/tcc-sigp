namespace VirtusGo.Core.Domain.Rota.Commands
{
    public class ExcluirRotaCommand : BaseRotaCommand
    {
        public ExcluirRotaCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}