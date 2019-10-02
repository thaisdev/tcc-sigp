using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Rastreabilidade.Commands
{
    public class RegistrarRastreabilidadeCommand : BaseRastreabilidadeCommand
    {
        public RegistrarRastreabilidadeCommand(
            int pedidoVendaId,
            int pedidoCompraId,
            int produtoID,
            int quantidade)
        {
            PedidoVendaId = pedidoVendaId;
            PedidoCompraId = pedidoCompraId;
            ProdutoId = produtoID;
            Quantidade = quantidade;
        }
    }
}
