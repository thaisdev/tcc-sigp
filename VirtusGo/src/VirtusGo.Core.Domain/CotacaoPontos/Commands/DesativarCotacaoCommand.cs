namespace VirtusGo.Core.Domain.CotacaoPontos.Commands
{
    public class DesativarCotacaoCommand : BaseCotacaoPontosCommand
    {
        public DesativarCotacaoCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}