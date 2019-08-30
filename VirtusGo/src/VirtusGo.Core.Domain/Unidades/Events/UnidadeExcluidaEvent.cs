namespace VirtusGo.Core.Domain.Unidades.Events
{
    public class UnidadeExcluidaEvent : BaseUnidadeEvent
    {
        public UnidadeExcluidaEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}