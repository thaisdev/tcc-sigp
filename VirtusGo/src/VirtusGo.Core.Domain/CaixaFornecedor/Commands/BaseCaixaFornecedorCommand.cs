using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.CaixaFornecedor.Commands
{
    public class BaseCaixaFornecedorCommand : Command
    {
        public int Id { get; protected set; }
        public int ParceiroId { get; protected set; }
        public DateTime Data { get; protected set; }
    }
}
