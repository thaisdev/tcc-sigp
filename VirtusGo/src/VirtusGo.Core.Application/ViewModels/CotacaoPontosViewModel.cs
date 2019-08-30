using System;
using System.ComponentModel.DataAnnotations;
using VirtusGo.Core.Domain.Enums;


namespace VirtusGo.Core.Application.ViewModels
{
    public class CotacaoPontosViewModel
    {
        [Key]
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataVigencia { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public int UsuarioIdCriacao { get; set; }
        public int UsuarioIdAlteracao { get; set; }
    }
}