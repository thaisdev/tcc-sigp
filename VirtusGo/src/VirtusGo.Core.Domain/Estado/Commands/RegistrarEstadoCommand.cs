namespace VirtusGo.Core.Domain.Estado.Commands
{
    public class RegistrarEstadoCommand : BaseEstadoCommand
    {
        public RegistrarEstadoCommand(int id, string nomeEstado, string siglaEstado)
        {
            Id = id;
            NomeEstado = nomeEstado;
            SiglaEstado = siglaEstado;

            AggregateId = id;
        }
    }
}