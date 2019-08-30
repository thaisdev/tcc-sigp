using System;
using System.ComponentModel.DataAnnotations;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Application.ViewModels
{
    public class BeneficiarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(60, ErrorMessage = "Máximo de {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione a Pessoa")]
        public TipoPessoaEnum TipPessoa { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(19, ErrorMessage = "Máximo de {0} caracteres")]
        public string NumeroDocumento { get; set; }

        [MaxLength(4, ErrorMessage = "Máximo de {0} caracteres")]
        [Required(ErrorMessage = "Preencha o campo DDD")]
        public string Ddd { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(10, ErrorMessage = "Máximo de {0} caracteres")]
        public string Telefone { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres")]
        [Required(ErrorMessage = "Preencha o campo Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo CEP")]
        [MaxLength(9, ErrorMessage = "Máximo de {0} caracteres")]
        public string Cep { get; set; }

        [MaxLength(40, ErrorMessage = "Máximo de {0} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Endereço")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MaxLength(2)]
        public string Uf { get; set; }

        [MaxLength(30, ErrorMessage = "Máximo de {0} caracteres")]
        [Required(ErrorMessage = "Preencha o campo Cidade")]
        public string Cidade { get; set; }

        public FlagExcluidoEnum Excluido { get; set; }

        public int UsuarioCriacaoId { get; set; }

        public int? UsuarioAlteracaoId { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }

    }
}
