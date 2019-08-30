namespace VirtusGo.Core.Domain.Faixas.Events
{
    public class FaixaExcluidaEvent : BaseFaixaEvent
    {
        public FaixaExcluidaEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}