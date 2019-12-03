using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.ItensPedidos.Commands
{
    public class BaseItensPedidoCommand : Command
    {
        public int Id { get; protected set; }
        public int ProdutoId { get; protected set; }
        public int PedidoId { get; protected set; }
        public double ValorUnitario { get; protected set; }
        public double ValorTotal { get; protected set; }
        public int Quantidade { get; protected set; }
    }
}