namespace VirtusGo.Core.Domain.Cidade.Commands
{
    public class AtualizarCidadeCommand : BaseCidadeCommand
    {
        public AtualizarCidadeCommand(int id, string nomeCidade, int estadoId)
        {
            Id = id;
            NomeCidade = nomeCidade;
            EstadoId = estadoId;
        }
    }
}