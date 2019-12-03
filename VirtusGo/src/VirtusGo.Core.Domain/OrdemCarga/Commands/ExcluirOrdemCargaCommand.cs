namespace VirtusGo.Core.Domain.OrdemCarga.Commands
{
    public class ExcluirOrdemCargaCommand : BaseOrdemCargaCommand
    {
        public ExcluirOrdemCargaCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}