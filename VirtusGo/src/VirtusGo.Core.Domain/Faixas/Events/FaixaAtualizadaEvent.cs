using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Faixas.Events
{
    public class FaixaAtualizadaEvent : BaseFaixaEvent
    {
        public FaixaAtualizadaEvent(double valorDe, double valorAte, double valorPorcentagem, FlagExcluidoEnum flagExcluido, DateTime dataCriacao, DateTime? dataAlteracao, int empresaId, int? unidadeId, int usuarioIdCriacao, int? usuarioIdAltera)
        {
            Id = Id;
            ValorDe = valorDe;
            ValorAte = valorAte;
            ValorPorcentagem = valorPorcentagem;
            FlagExcluido = flagExcluido;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            EmpresaId = empresaId;
            UnidadeId = unidadeId;
            UsuarioIdCriacao = usuarioIdCriacao;
            UsuarioIdAltera = usuarioIdAltera;

            AggregateId = Id;
        }
    }
}