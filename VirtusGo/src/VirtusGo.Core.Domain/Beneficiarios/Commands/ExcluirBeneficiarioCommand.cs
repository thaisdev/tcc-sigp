namespace VirtusGo.Core.Domain.Beneficiarios.Commands
{
    public class ExcluirBeneficiarioCommand : BaseBeneficiarioCommand
    {
        public ExcluirBeneficiarioCommand(int id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}