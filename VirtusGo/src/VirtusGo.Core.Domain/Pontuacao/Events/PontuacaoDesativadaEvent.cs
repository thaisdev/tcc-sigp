using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Pontuacao.Events
{
    public class PontuacaoDesativadaEvent : BasePontuacaoEvent
    {
        public PontuacaoDesativadaEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
