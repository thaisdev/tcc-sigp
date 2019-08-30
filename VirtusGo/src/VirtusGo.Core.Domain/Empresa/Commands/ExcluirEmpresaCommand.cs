namespace VirtusGo.Core.Domain.Empresa.Commands
{
    public class ExcluirEmpresaCommand : BaseEmpresaCommand
    {
        public ExcluirEmpresaCommand(int id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}