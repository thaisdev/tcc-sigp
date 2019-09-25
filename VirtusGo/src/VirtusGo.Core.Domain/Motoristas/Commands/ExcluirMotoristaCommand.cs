using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Motoristas.Commands
{
    public class ExcluirMotoristaCommand : BaseMotoristaCommand
    {
        public ExcluirMotoristaCommand(int id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
