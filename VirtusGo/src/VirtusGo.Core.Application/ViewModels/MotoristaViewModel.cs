using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtusGo.Core.Application.ViewModels
{
    public class MotoristaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CategoriaCNH { get; set; }
        public string NumeroCNH { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataVencimentoCNH { get; set; }

        public int EnderecoId { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public int CidadeId { get; set; }

        public string Cep { get; set; }

        [NotMapped] public EnderecoViewModel Endereco { get; set; }
    }
}