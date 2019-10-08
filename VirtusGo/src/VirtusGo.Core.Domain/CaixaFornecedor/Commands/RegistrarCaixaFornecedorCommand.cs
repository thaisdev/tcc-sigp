using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.CaixaFornecedor.Commands
{
    public class RegistrarCaixaFornecedorCommand : BaseCaixaFornecedorCommand
    {
        public RegistrarCaixaFornecedorCommand(
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
