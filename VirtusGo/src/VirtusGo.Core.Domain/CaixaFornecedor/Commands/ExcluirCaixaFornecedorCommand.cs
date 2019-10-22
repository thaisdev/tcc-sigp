using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.CaixaFornecedor.Commands
{
    public class ExcluirCaixaFornecedorCommand : BaseCaixaFornecedorCommand
    {
        public ExcluirCaixaFornecedorCommand(int id)
        {
            Id = id;

            AggregateId = Id;
        }
    }
}
