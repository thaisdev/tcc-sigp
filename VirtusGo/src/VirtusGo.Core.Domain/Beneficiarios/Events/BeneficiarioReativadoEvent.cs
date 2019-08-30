using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Beneficiarios.Events
{
    public class BeneficiarioReativadoEvent : BaseBeneficiarioEvent
    {
        public BeneficiarioReativadoEvent(int id, string nome,
            TipoPessoaEnum tipPessoa, string numeroDocumento,
            string ddd, string telefone,
            string email, string cep,
            string bairro, string endereco,
            string uf, string cidade,
            FlagExcluidoEnum excluido, int usuarioCriacaoId,
            int? usuarioAlteracaoId, DateTime dataCadastro,
            DateTime? dataAlteracao)
        {
            Id = id;
            Nome = nome;
            TipPessoa = tipPessoa;
            NumeroDocumento = numeroDocumento;
            Ddd = ddd;
            Telefone = telefone;
            Email = email;
            Cep = cep;
            Bairro = bairro;
            Endereco = endereco;
            Uf = uf;
            Cidade = cidade;
            Excluido = excluido;
            UsuarioCriacaoId = usuarioCriacaoId;
            UsuarioAlteracaoId = usuarioAlteracaoId;
            DataCadastro = dataCadastro;
            DataAlteracao = dataAlteracao;

            AggregateId = Id;
        }
    }
}