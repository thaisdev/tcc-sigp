using System;
using VirtusGo.Core.Domain.Core.Command;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Faixas.Commands
{
    public class BaseFaixaCommand : Command
    {
        public int Id { get; set; }
        public double ValorDe { get; set; }
        public double ValorAte { get; set; }
        public double ValorPorcentagem { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresas Empresa { get; set; }
        public int? UnidadeId { get; set; }
        public virtual Unidades.Unidade Unidades { get; set; }
        public int UsuarioIdCriacao { get; set; }
        //public virtual Usuario Usuario { get; set; }
        public int? UsuarioIdAltera { get; set; }
    }
}