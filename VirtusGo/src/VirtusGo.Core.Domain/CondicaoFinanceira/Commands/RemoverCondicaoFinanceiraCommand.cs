using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.CondicaoFinanceira.Commands
{
    public class RemoverCondicaoFinanceiraCommand : BaseCondicaoFinanceiraCommand
    {
        public RemoverCondicaoFinanceiraCommand(int id, int dias, int parcelas)
        {
            Id = id;
            Dias = dias;
            Parcelas = parcelas;
            AggregateId = Id;
        }
    }
}