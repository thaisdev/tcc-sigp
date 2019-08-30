namespace VirtusGo.Core.Domain.Empresa.Events
{
    public class EmpresaExcluidaEvent : BaseEmpresaEvent
    {
        public EmpresaExcluidaEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}