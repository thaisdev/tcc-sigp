namespace VirtusGo.Core.Domain.PontuacaoPdv.Events
{
    public class PdvAprovadoEvent : BasePdvEvent
    {
        public PdvAprovadoEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}