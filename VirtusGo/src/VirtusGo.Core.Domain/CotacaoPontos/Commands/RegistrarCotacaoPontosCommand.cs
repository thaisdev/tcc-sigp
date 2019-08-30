using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.CotacaoPontos.Commands
{
    public class RegistrarCotacaoPontosCommand : BaseCotacaoPontosCommand
    {
        public RegistrarCotacaoPontosCommand(double valor, DateTime dataVigencia, FlagExcluidoEnum flagExcluido, DateTime dataCriacao, DateTime? dataAlteracao, int usuarioIdCriacao, int? usuarioIdAltera)
        {
            Id = Id;
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