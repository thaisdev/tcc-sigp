using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.Motoristas.Commands
{
    public class RegistrarMotoristaCommand : BaseMotoristaCommand
    {
        public RegistrarMotoristaCommand(
            int id,
            string nome,
            string cpf,
            string categoriaCnh,
            string numeroCnh,
            string telefone,
            DateTime dataNascimento,
            DateTime dataVencimentoCnh,
            int enderecoId)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            CategoriaCNH = categoriaCnh;
            NumeroCNH = numeroCnh;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            DataVencimentoCNH = dataVencimentoCnh;
            EnderecoId = enderecoId;

            AggregateId = Id;
        }
    }
}
