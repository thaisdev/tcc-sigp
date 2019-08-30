using System;
using System.ComponentModel.DataAnnotations;
using VirtusGo.Core.Domain.Beneficiarios;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Unidades;

namespace VirtusGo.Core.Application.ViewModels
{
    public class PontuacaoViewModel
    {
        public int Id { get; set; }
        public int BeneficiarioId { get; set; }
        public double ValorLancamento { get; set; }
        public int UsuarioIdCriacao { get; set; }
        public int? UsuarioIdAlteracao { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public string FlagInterface { get; set; }
        public DateTime? DataInterface { get; set; }
        public int? UsuarioIdInterface { get; set; }
        public string FlagErroInterface { get; set; }
        public string DescricaoErroInterface { get; set; }
        public int EmpresaId { get; set; }
        public int? UnidadeId { get; set; }
        public virtual Unidade Unidade { get; set; }
        public virtual Beneficiario Beneficiarios { get; set; }
        public virtual Empresas Empresa { get; set; }
        //[ScaffoldColumn(false)]
        //public Usuario Usuario { get; set; }
    }
}