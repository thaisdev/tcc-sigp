using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Parametro.Event
{
    public class ParametroAtualizadoEvent : BaseParametroEvent
    {
        public ParametroAtualizadoEvent(int id, int diasParaExpiracaoPontos, double valorComissaoGeral, double? valorPorcentagemGeralPontosFaixa, FlagExcluidoEnum flagExcluido,
            DateTime dataCriacao, DateTime? dataAlteracao, int usuarioIdCriacao, int? usuarioIdAlteracao)
        {
            Id = id;
            DiasParaExpiracaoPontos = diasParaExpiracaoPontos;
            ValorComissaoGeral = valorComissaoGeral;
            ValorPorcentagemGeralPontosFaixa = valorPorcentagemGeralPontosFaixa;
            FlagExcluido = flagExcluido;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            UsuarioIdCriacao = usuarioIdCriacao;
            UsuarioIdAlteracao = usuarioIdAlteracao;

            AggregateId = id;

        }
    }
}