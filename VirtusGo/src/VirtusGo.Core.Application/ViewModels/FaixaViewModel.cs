using System;
using System.ComponentModel.DataAnnotations;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Unidades;

namespace VirtusGo.Core.Application.ViewModels
{
    public class FaixaViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required( ErrorMessage = "Preencha o campo Valor De")]
        public double ValorDe { get; set; }
        [Required(ErrorMessage = "Preencha o campo Valor Até")]
        public double ValorAte { get; set; }
        [Required(ErrorMessage = "Preencha o campo % de pontos")]
        public double ValorPorcentagem { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresas Empresa { get; set; }
        public int? UnidadeId { get; set; }
        public virtual Unidade Unidades { get; set; }
        public int UsuarioIdCriacao { get; set; }
        //public virtual Usuario Usuario { get; set; }
        public int? UsuarioIdAltera { get; set; }
    }
}