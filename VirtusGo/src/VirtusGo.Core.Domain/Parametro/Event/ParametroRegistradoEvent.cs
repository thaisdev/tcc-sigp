using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Parametro.Event
{
    public class ParametroRegistradoEvent : BaseParametroEvent
    {
        public ParametroRegistradoEvent(int id, int diasParaExpiracaoPontos, double valorComissaoGeral, FlagExcluidoEnum flagExcluido,
            DateTime dataCriacao, DateTime? dataAlteracao, int usuarioIdCriacao, int? usuarioIdAlteracao)
        {
            Id = id;
            DiasParaExpiracaoPontos = diasParaExpiracaoPontos;
            ValorComissaoGeral = valorComissaoGeral;
            FlagExcluido = flagExcluido;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            UsuarioIdCriacao = usuarioIdCriacao;
            UsuarioIdAlteracao = usuarioIdAlteracao;

            AggregateId = id;

        }
    }
}