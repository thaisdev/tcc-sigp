using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Faixas.Commands
{
    public class AtualizarFaixaCommand : BaseFaixaCommand
    {
        public AtualizarFaixaCommand(int id, double valorDe, double valorAte, double valorPorcentagem, FlagExcluidoEnum flagExcluido, DateTime dataCriacao, DateTime? dataAlteracao, int empresaId, int? unidadeId, int usuarioIdCriacao, int? usuarioIdAltera)
        {
            Id = id;
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