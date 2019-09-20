namespace VirtusGo.Core.Domain.Parceiro.Commands
{
    public class ExcluirParceiroCommand : BaseParceiroCommand
    {
        public ExcluirParceiroCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}