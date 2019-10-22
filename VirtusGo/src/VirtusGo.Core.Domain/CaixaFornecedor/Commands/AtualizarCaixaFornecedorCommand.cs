using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.CaixaFornecedor.Commands
{
    public class AtualizarCaixaFornecedorCommand : BaseCaixaFornecedorCommand
    {
        public AtualizarCaixaFornecedorCommand(
            int id,
            int parceiroId,
            DateTime data)
        {
            Id = id;
            ParceiroId = parceiroId;
            Data = data;

            AggregateId = Id;
        }
    }
}
