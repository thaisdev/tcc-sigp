using VirtusGo.Core.Domain.Core.Command;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Parceiro.Commands
{
    public class BaseParceiroCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string NumeroDocumento { get; protected set; }
        public int EnderecoId { get; protected set; }
        public string Email { get; protected set; }
        public TipoPessoaEnum TipoPessoa { get; protected set; }
        public string RgInscricaoEstadual { get; protected set; }
        public string Site { get; protected set; }
        public string Telefone { get; protected set; }
    }
}