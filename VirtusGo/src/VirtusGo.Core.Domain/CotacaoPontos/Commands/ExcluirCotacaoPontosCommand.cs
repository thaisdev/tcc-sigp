namespace VirtusGo.Core.Domain.CotacaoPontos.Commands
{
    public class ExcluirCotacaoPontosCommand : BaseCotacaoPontosCommand
    {
        public ExcluirCotacaoPontosCommand(int id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}