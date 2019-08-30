using System;
using System.ComponentModel.DataAnnotations;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Unidades;

namespace VirtusGo.Core.Application.ViewModels
{
    public class PontuacaoPdvViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Valor de lançamento")]
        public double ValorLancamento { get; set; }
        public DateTime DataCompra { get; set; }
        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(18, ErrorMessage = "Máximo de {0} caracteres")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Preencha o Campo Operador")]
        [MaxLength(60, ErrorMessage = "Máximo de {0} caracteres")]
        public string Operador { get; set; }
        [Required(ErrorMessage = "Preencha o campo E-Mail")]
        [MaxLength(60, ErrorMessage = "Máximo de {0} caracteres")]
        public string Email { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public string FlagInterface { get; set; }
        public DateTime? DataInterface { get; set; }
        public int? UsuarioIdInterface { get; set; }
        public string FlagErroInterface { get; set; }
        public string MensagemErroInterface { get; set; }
        public int UnidadeId { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresas Empresa { get; set; }
        public virtual Unidade Unidade { get; set; }
        //public virtual Usuario Usuario { get; set; }
    }
}