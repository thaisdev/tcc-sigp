using System;
using VirtusGo.Core.Domain.Core.Command;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Beneficiarios.Commands
{
    public class BaseBeneficiarioCommand : Command
    {
        public int Id { get; protected set; }

        public string Nome { get; protected set; }

        public TipoPessoaEnum TipPessoa { get; protected set; }

        public string NumeroDocumento { get; protected set; }

        public string Ddd { get; protected set; }

        public string Telefone { get; protected set; }

        public string Email { get; protected set; }

        public string Cep { get; protected set; }

        public string Bairro { get; protected set; }

        public string Endereco { get; protected set; }


        public string Uf { get; protected set; }


        public string Cidade { get; protected set; }


        public FlagExcluidoEnum Excluido { get; protected set; }

        public int UsuarioCriacaoId { get; protected set; }

        public int? UsuarioAlteracaoId { get; protected set; }

        public DateTime DataCadastro { get; protected set; }

        public DateTime? DataAlteracao { get; protected set; }
    }
}