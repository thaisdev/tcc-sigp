namespace VirtusGo.Core.Domain.CotacaoPontos.Events
{
    public class CotacaoDesativadaEvent : BaseCotacaoPontosEvent
    {
        public CotacaoDesativadaEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}