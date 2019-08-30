using System;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Unidades;

namespace VirtusGo.Core.Application.ViewModels
{
    public class ListarFaixaViewModel
    {
        public int Id { get; set; }
        public double ValorDe { get; set; }
        public double ValorAte { get; set; }
        public double ValorPorcentagem { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int EmpresaId { get; set; }
        public string Empresa { get; set; }
        public int? UnidadeId { get; set; }
        public string Unidade { get; set; }
        public int UsuarioIdCriacao { get; set; }
        //public virtual Usuario Usuario { get; set; }
        public int? UsuarioIdAltera { get; set; }
    }
}