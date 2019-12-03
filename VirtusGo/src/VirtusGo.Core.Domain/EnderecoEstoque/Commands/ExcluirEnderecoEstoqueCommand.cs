using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.EnderecoEstoque.Commands
{
    public class ExcluirEnderecoEstoqueCommand : BaseEnderecoEstoqueCommand
    {
        public ExcluirEnderecoEstoqueCommand(int id)
        {
            Id = id;

            AggregateId = Id;
        }
    }
}
