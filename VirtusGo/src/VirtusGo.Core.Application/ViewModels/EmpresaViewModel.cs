using System;
using System.ComponentModel.DataAnnotations;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Application.ViewModels
{
    public class EmpresaViewModel
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Razao Social")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome Fantasia")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(19, ErrorMessage = "Máximo 19 caracteres")]
        public string NumeroDocumento { get; set; }

        public FlagBloqueadoEnum Bloqueado { get; set; }

        public FlagExcluidoEnum Excluido { get; set; }

        [Required(ErrorMessage = "Preencha o campo Email")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        [Required(ErrorMessage = "Preencha o campo CEP")]
        [MaxLength(9, ErrorMessage = "Máximo 9 caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Endereco")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Endereco { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        [Required(ErrorMessage = "Preencha o campo Ramo")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Ramo { get; set; }

        public ProfissionalLiberal ProfissionalLiberal { get; set; }

        public PlanosParceiros Plano { get; set; }

        public string Uf { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Contato")]
        [MaxLength(40, ErrorMessage = "Máximo 40 caracteres")]
        public string Contato { get; set; }

        public string Contato2 { get; set; }

        [Required(ErrorMessage = "Preencha o campo DDD")]
        public string Ddd { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres")]
        public string Telefone { get; set; }

        public string Ddd2 { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres")]
        public string Telefone2 { get; set; }

        public string Ddd3 { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres")]
        public string Telefone3 { get; set; }

        public int? QuantidadeFilial { get; set; }

        public int? DiasParaExpiracaoPontos { get; set; }

        public double? ValorComissãoGeral { get; set; }

        //Porcentagem geral para os pontos.
        //Este valor será utilizado quando não existir "porcentagem de ponto" para determinado valor no cadastro de Faixa.
        public double? PorcentagemPadraoPontos { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int UsuarioIdCriacao { get; set; }

        public int? UsuarioIdAlteracao { get; set; }
    }
}