namespace VirtusGo.Core.Domain.PontuacaoPdv.Events
{
    public class PdvExcluidoEvent : BasePdvEvent
    {
        public PdvExcluidoEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}