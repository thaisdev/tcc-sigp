using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.Motoristas.Commands
{
    public class BaseMotoristaCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string CPF { get; protected set; }
        public string CategoriaCNH { get; protected set; }
        public string NumeroCNH { get; protected set; }
        public string Telefone { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public DateTime DataVencimentoCNH { get; protected set; }
        public int EnderecoId { get; protected set; }
    }
}
