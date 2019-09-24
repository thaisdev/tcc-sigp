using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Empresas.Commands
{
    public class AtualizarEmpresaCommand : BaseEmpresaCommand
    {
        public AtualizarEmpresaCommand(
            int id,
            string razao,
            string cnpj,
            string inscri,
            int enderecoId
        )
        {
            Id = id;
            Razao = razao;
            CNPJ = cnpj;
            Inscri = inscri;
            EnderecoId = enderecoId;

            AggregateId = id;
        }
    }
}
