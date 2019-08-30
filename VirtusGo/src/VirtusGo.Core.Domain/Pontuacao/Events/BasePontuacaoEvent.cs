using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Pontuacao.Events
{
    public class BasePontuacaoEvent : Event
    {
        public int Id { get; protected set; }
        public int BeneficiarioId { get; protected set; }
        public double ValorLancamento { get; protected set; }
        public int UsuarioIdCriacao { get; protected set; }
        public int? UsuarioIdAlteracao { get; protected set; }
        public DateTime DataCompra { get; protected set; }
        public DateTime DataLancamento { get; protected set; }
        public DateTime? DataAlteracao { get; protected set; }
        public FlagExcluidoEnum FlagExcluido { get; protected set; }
        public string FlagInterface { get; protected set; }
        public DateTime? DataInterface { get; protected set; }
        public int? UsuarioIdInterface { get; protected set; }
        public string FlagErroInterface { get; protected set; }
        public string DescricaoErroInterface { get; protected set; }
        public int EmpresaId { get; protected set; }
        public int? UnidadeId { get; protected set; }
    }
}
