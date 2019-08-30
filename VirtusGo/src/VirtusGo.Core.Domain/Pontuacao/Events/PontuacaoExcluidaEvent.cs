using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Pontuacao.Events
{
    public class PontuacaoExcluidaEvent : BasePontuacaoEvent
    {
        public PontuacaoExcluidaEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
