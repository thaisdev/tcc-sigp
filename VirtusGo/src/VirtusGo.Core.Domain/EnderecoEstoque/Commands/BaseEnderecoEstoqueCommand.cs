using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.EnderecoEstoque.Commands
{
    public class BaseEnderecoEstoqueCommand : Command
    {
        public int Id { get; protected set; }
        public string DescricaoEndereco { get; protected set; }
        public string Rua { get; protected set; }
        public string Coluna { get; protected set; }
    }
}
