using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.EnderecoEstoque.Commands
{
    public class RegistrarEnderecoEstoqueCommand : BaseEnderecoEstoqueCommand
    {
        public RegistrarEnderecoEstoqueCommand(
            int id,
            string descricaoEndereco,
            string rua,
            string coluna)
        {
            Id = id;
            DescricaoEndereco = descricaoEndereco;
            Rua = rua;
            Coluna = coluna;

            AggregateId = Id;
        }
    }
}
