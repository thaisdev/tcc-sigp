using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Application.ViewModels
{
    public class ParceiroViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroDocumento { get; set; }
        public int EnderecoId { get; set; }
        public string Email { get; set; }
        public TipoPessoaEnum TipoPessoa { get; set; }
        public string RgInscricaoEstadual { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
    }
}