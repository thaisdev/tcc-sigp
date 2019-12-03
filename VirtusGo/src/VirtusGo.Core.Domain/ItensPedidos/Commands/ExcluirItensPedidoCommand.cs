using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.ItensPedidos.Commands
{
    public class ExcluirItensPedidoCommand : BaseItensPedidoCommand
    {
        public ExcluirItensPedidoCommand(int id)
        {
            Id = id;

            AggregateId = Id;
        }
    }
}
