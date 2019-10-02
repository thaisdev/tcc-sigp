using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Pedidos.Commands
{
    public class ExcluirPedidoCommand : BasePedidoCommand
    {
        public ExcluirPedidoCommand(int id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
