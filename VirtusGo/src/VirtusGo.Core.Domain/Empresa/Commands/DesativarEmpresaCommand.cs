namespace VirtusGo.Core.Domain.Empresa.Commands
{
    public class DesativarEmpresaCommand : BaseEmpresaCommand
    {
        public DesativarEmpresaCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}