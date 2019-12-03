namespace VirtusGo.Core.Domain.CondicaoFinanceira.Commands
{
    public class AtualizarCondicaoFinanceiraCommand : BaseCondicaoFinanceiraCommand
    {

        public AtualizarCondicaoFinanceiraCommand(int id, int parcelas, int dias)
        {
            Id = id;
            Parcelas = parcelas;
            Dias = dias;
        }
    }
}