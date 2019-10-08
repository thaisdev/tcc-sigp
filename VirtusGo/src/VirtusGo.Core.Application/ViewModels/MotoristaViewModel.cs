using System;

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
    }
}