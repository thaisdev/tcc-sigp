namespace VirtusGo.Core.Domain.Parametro.Event
{
    public class ParametroDesativadoEvent : BaseParametroEvent
    {
        public ParametroDesativadoEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}