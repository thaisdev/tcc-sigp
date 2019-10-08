using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.ItensPedidos.Commands
{
    public class RegistrarItensPedidoCommand : BaseItensPedidoCommand
    {
        public RegistrarItensPedidoCommand(
            int id,
            int produtoId,
            double valorUnitario,
            double valorTotal, int quantidade)
        {
            Id = id;
            ProdutoId = produtoId;
            ValorUnitario = valorUnitario;
            ValorTotal = valorTotal;
            Quantidade = quantidade;

            AggregateId = Id;
        }
    }
}