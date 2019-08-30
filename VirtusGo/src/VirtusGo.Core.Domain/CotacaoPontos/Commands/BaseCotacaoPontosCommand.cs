using System;
using VirtusGo.Core.Domain.Core.Command;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.CotacaoPontos.Commands
{
    public class BaseCotacaoPontosCommand : Command
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataVigencia { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int UsuarioIdCriacao { get; set; }
        public int? UsuarioIdAltera { get; set; }
    }
}