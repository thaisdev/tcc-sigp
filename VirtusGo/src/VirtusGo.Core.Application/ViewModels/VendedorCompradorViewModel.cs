using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Application.ViewModels
{
    public class VendedorCompradorViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public FlagCompradorVendedorEnum Vendedor { get;  set; }
        public FlagCompradorVendedorEnum Comprador { get; set; }
        public double Comissao { get; set; }
    }
}
