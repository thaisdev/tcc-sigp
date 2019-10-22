using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Command;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.VendedorComprador.Commands
{
    public class BaseVendedorCompradorCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public FlagCompradorVendedorEnum Vendedor { get; protected set; }
        public FlagCompradorVendedorEnum Comprador { get; protected set; }
        public double Comissao { get; protected set; }
    }
}
