using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Produtos.Commands
{
    public class RegistrarProdutoCommand : BaseProdutoCommand
    {
        public RegistrarProdutoCommand(
            int id,
            string descricao,
            string unidade,
            double valorUnitario,
            int estoque,
            string ncm
            )
        {
            Id = id;
            Descricao = descricao;
            Unidade = unidade;
            ValorUnitario = valorUnitario;
            Estoque = estoque;
            NCM = ncm;

            AggregateId = Id;
        }
    }
}
