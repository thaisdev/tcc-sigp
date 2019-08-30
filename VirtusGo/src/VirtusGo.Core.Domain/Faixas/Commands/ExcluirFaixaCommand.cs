namespace VirtusGo.Core.Domain.Faixas.Commands
{
    public class ExcluirFaixaCommand : BaseFaixaCommand
    {
        public ExcluirFaixaCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}