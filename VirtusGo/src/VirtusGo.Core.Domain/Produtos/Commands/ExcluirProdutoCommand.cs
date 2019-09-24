using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Produtos.Commands
{
    public class ExcluirProdutoCommand : BaseProdutoCommand
    {
        public ExcluirProdutoCommand(int id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
