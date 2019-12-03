using System.ComponentModel.DataAnnotations.Schema;
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

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public int CidadeId { get; set; }

        public string Cep { get; set; }

        [NotMapped] public EnderecoViewModel Endereco { get; set; }
    }
}