namespace VirtusGo.Core.Domain.Estado.Commands
{
    public class AtualizarEstadoCommand : BaseEstadoCommand
    {
        public AtualizarEstadoCommand(int id, string nomeEstado, string siglaEstado)
        {
            Id = id;
            NomeEstado = nomeEstado;
            SiglaEstado = siglaEstado;
        }
    }
}