using System.ComponentModel.DataAnnotations.Schema;

namespace VirtusGo.Core.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public string Cep { get; set; }

        [NotMapped] public CidadeViewModel Cidade { get; set; }
    }
}