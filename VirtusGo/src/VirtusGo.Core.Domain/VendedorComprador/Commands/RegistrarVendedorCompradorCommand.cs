using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.VendedorComprador.Commands
{
    public class RegistrarVendedorCompradorCommand : BaseVendedorCompradorCommand
    {
        public RegistrarVendedorCompradorCommand(
            int id,
            string nome,
            FlagCompradorVendedorEnum vendedor,
            FlagCompradorVendedorEnum comprador,
            double comissao
            )
        {
            Id = id;
            Nome = nome;
            Vendedor = vendedor;
            Comprador = comprador;
            Comissao = comissao;
        }
    }
}
