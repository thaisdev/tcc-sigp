﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.ItensPedidos.Commands
{
    public class AtualizarItensPedidoCommand : BaseItensPedidoCommand
    {
        public AtualizarItensPedidoCommand(
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