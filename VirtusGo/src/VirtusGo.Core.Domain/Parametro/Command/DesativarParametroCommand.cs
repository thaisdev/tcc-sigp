namespace VirtusGo.Core.Domain.Parametro.Command
{
    public class DesativarParametroCommand : BaseParametroCommand
    {
        public DesativarParametroCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}