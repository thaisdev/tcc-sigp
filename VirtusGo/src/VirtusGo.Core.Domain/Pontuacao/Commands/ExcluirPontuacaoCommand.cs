using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Pontuacao.Commands
{
    public class ExcluirPontuacaoCommand : BasePontuacaoCommand
    {
        public ExcluirPontuacaoCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
