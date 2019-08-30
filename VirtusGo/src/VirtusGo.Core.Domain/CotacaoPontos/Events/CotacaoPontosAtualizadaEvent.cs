using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.CotacaoPontos.Events
{
    public class CotacaoPontosAtualizadaEvent : BaseCotacaoPontosEvent
    {
        public CotacaoPontosAtualizadaEvent(int id, double valor, DateTime dataVigencia, FlagExcluidoEnum flagExcluido, DateTime dataCriacao, DateTime? dataAlteracao, int usuarioIdCriacao, int? usuarioIdAltera)
        {
            Id = id;
            Valor = valor;
            DataVigencia = dataVigencia;
            FlagExcluido = flagExcluido;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            UsuarioIdCriacao = usuarioIdCriacao;
            UsuarioIdAltera = usuarioIdAltera;

            AggregateId = Id;
        }
    }
}