namespace VirtusGo.Core.Domain.Unidades.Events
{
    public class UnidadeReativadaEvent : BaseUnidadeEvent
    {
        public UnidadeReativadaEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}