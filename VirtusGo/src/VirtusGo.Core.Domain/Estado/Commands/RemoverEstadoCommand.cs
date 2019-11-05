namespace VirtusGo.Core.Domain.Estado.Commands
{
    public class RemoverEstadoCommand : BaseEstadoCommand
    {
        public RemoverEstadoCommand(int id, string nomeEstado, string siglaEstado)
        {
            Id = id;
            NomeEstado = nomeEstado;
            SiglaEstado = siglaEstado;
            AggregateId = Id;
        }
    }
}