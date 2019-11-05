using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.Produtos.Commands
{
    public class BaseProdutoCommand : Command
    {
        public int Id { get; protected set; }
        public string Descricao { get; protected set; }
        public string Unidade { get; protected set; }
        public double ValorUnitario { get; protected set; }
        public int Estoque { get; protected set; }
        public string NCM { get; protected set; }
    }
}