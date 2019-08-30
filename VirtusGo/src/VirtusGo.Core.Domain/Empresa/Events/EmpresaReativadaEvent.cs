namespace VirtusGo.Core.Domain.Empresa.Events
{
    public class EmpresaReativadaEvent : BaseEmpresaEvent
    {
        public EmpresaReativadaEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}