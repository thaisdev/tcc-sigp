namespace VirtusGo.Core.Domain.CondicaoFinanceira.Commands
{
    public class RegistrarCondicaoFinanceiraCommand : BaseCondicaoFinanceiraCommand
    {

        public RegistrarCondicaoFinanceiraCommand(int id, int parcelas, int dias)
        {
            Id = id;
            Parcelas = parcelas;
            Dias = dias;

            AggregateId = id;
        }
    }
}