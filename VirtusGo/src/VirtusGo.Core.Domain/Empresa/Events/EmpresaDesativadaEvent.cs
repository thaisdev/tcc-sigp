namespace VirtusGo.Core.Domain.Empresa.Events
{
    public class EmpresaDesativadaEvent : BaseEmpresaEvent
    {
        public EmpresaDesativadaEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}