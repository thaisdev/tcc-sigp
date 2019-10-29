using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Parceiro.Commands
{
    public class AtualizarParceiroCommand : BaseParceiroCommand
    {
        public AtualizarParceiroCommand(int id, string nome, string numeroDocumento, int enderecoId, string email,
            TipoPessoaEnum tipoPessoa, string rgInscricaoEstadual, string site, string telefone)
        {
            Id = id;
            Nome = nome;
            NumeroDocumento = numeroDocumento;
            EnderecoId = enderecoId;
            Email = email;
            TipoPessoa = tipoPessoa;
            RgInscricaoEstadual = rgInscricaoEstadual;
            Site = site;
            Telefone = telefone;
        }
    }
}