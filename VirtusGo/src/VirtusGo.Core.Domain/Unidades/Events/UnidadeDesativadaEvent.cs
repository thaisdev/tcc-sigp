namespace VirtusGo.Core.Domain.Unidades.Events
{
    public class UnidadeDesativadaEvent : BaseUnidadeEvent
    {
        public UnidadeDesativadaEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}