namespace VirtusGo.Core.Domain.Rota.Commands
{
    public class RegistrarRotaCommand : BaseRotaCommand
    {
        public RegistrarRotaCommand(int id, int enderecoId)
        {
            Id = id;
            EnderecoId = enderecoId;
            AggregateId = id;
        }
    }
}