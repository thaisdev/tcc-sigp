using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Command;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Empresas.Commands
{
    public class BaseEmpresaCommand : Command
    {
        public int Id { get; protected set; }
        public string Razao { get; protected set; }
        public string CNPJ { get; protected set; }
        public string Inscri { get; protected set; }
        public int EnderecoId { get; protected set; }

    }
}
