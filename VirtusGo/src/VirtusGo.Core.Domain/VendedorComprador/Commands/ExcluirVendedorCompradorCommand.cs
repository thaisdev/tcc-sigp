using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.VendedorComprador.Commands
{
    public class ExcluirVendedorCompradorCommand : BaseVendedorCompradorCommand
    {
        public ExcluirVendedorCompradorCommand(int id)
        {
            Id = id;

            AggregateId = Id;
        }
    }
}
