namespace VirtusGo.Core.Domain.Beneficiarios.Events
{
    public class BeneficiarioExcluidoEvent : BaseBeneficiarioEvent
    {
        public BeneficiarioExcluidoEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}