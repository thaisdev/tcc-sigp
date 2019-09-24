using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Empresas.Commands
{
    public class ExcluirEmpresaCommand : BaseEmpresaCommand
    {
        public ExcluirEmpresaCommand(int id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
