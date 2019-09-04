using System;
using System.ComponentModel.DataAnnotations;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Application.ViewModels
{
    public class UnidadeViewModel
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(60, ErrorMessage = "Máximo de {0} caracteres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome Fantasia")]
        [MaxLength(60, ErrorMessage = "Máximo de {0} caracteres")]
        public string Fantasia { get; set; }

        [Required(ErrorMessage = "Preencha o campo Documento")]
        [MaxLength(18, ErrorMessage = "Máximo de {0} caracteres")]
        public string Documento { get; set; }

        [MaxLength(60, ErrorMessage = "Máximo de {0} caracteres")]
        public string Email { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo de {0} caracteres")]
        [Required(ErrorMessage = "Preencha o campo DDD")]
        public string Ddd { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone")]
        [MaxLength(10, ErrorMessage = "Máximo de {0} caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo CEP")]
        [MaxLength(9, ErrorMessage = "Máximo de {0} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Endereço")]
        [MaxLength(60, ErrorMessage = "Máximo de {0} caracteres")]
        public string Endereco { get; set; }

        public string Latitude { get; set; }
        
        public string Longitude { get; set; }
        
        [Required(ErrorMessage = "Preencha o campo Ramo")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Ramo { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo de {0} caracteres")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(60, ErrorMessage = "Máximo de {0} caracteres")]
        public string Cidade { get; set; }

        public FlagBloqueadoEnum FlagBloqueado { get; set; }

        public FlagExcluidoEnum FlagExcluido { get; set; }

        public int UsuarioIdCriador { get; set; }

        public int? UsuarioIdAltera { get; set; }

        //public virtual Usuario Usuario { get; set; }

        public int EmpresaId { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int? NumeroDiasParaExpiracaoPontos { get; set; }
        public double? ComissaoGeral { get; set; }
        public double? ValorPorcentagemGeralPontos { get; set; }
    }
}