using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.CondicaoFinanceira.Commands
{
    public class BaseCondicaoFinanceiraCommand : Command
    {

        public int Id { get; protected set; }

        public int Parcelas { get; protected set; }

        public int Dias { get; protected set; }
    }
}