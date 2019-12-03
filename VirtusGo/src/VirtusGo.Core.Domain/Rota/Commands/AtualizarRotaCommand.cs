namespace VirtusGo.Core.Domain.Rota.Commands
{
    public class AtualizarRotaCommand : BaseRotaCommand
    {
        public AtualizarRotaCommand(int id, int enderecoId)
        {
            Id = id;
            EnderecoId = enderecoId;
        }
    }
}