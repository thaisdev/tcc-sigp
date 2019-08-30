namespace VirtusGo.Core.Domain.CotacaoPontos.Events
{
    public class CotacaoPontosExcluidoEvent : BaseCotacaoPontosEvent
    {
        public CotacaoPontosExcluidoEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}