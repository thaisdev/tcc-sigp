using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.Rastreabilidade.Commands
{
    public class BaseRastreabilidadeCommand : Command
    {
        public int PedidoVendaId { get; protected set; }
        public int PedidoCompraId { get; protected set; }
        public int ProdutoId { get; protected set; }
        public int Quantidade { get; protected set; }
    }
}
