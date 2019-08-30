using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Parametro.Command
{
    public class BaseParametroCommand : Core.Command.Command
    {
        public int Id { get; protected set; }
        public int DiasParaExpiracaoPontos { get; protected set; }
        public double ValorComissaoGeral { get; protected set; }
        public double? ValorPorcentagemGeralPontosFaixa { get; protected set; }
        public FlagExcluidoEnum FlagExcluido { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public DateTime? DataAlteracao { get; protected set; }
        public int UsuarioIdCriacao { get; protected set; }
        public int? UsuarioIdAlteracao { get; protected set; }
    }
}