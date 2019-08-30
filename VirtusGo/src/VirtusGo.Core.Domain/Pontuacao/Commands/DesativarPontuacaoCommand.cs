using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Pontuacao.Commands
{
    public class DesativarPontuacaoCommand : BasePontuacaoCommand
    {
        public DesativarPontuacaoCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
