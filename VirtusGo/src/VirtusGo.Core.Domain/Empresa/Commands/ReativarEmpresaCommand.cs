namespace VirtusGo.Core.Domain.Empresa.Commands
{
    public class ReativarEmpresaCommand : BaseEmpresaCommand
    {
        public ReativarEmpresaCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}