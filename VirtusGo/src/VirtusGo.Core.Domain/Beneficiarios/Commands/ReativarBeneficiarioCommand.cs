namespace VirtusGo.Core.Domain.Beneficiarios.Commands
{
    public class ReativarBeneficiarioCommand : BaseBeneficiarioCommand
    {
        public ReativarBeneficiarioCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}