using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Pontuacao.Events
{
    public class PontuacaoRegistradaEvent : BasePontuacaoEvent
    {
        public PontuacaoRegistradaEvent(int beneficiarioId,
            double valorLancamento,
            int usuarioIdCriacao,
            int? usuarioIdAlteracao,
            DateTime dataCompra,
            DateTime dataLancamento,
            DateTime? dataAlteracao,
            FlagExcluidoEnum flagExcluido,
            string flagInterface,
            DateTime? dataInterface,
            int? usuarioIdInterface,
            string flagErroInterface,
            string descricaoErroInterface,
            int empresaId,
            int? unidadeId)
        {
            Id = Id;
            BeneficiarioId = beneficiarioId;
            ValorLancamento = valorLancamento;
            UsuarioIdCriacao = usuarioIdCriacao;
            UsuarioIdAlteracao = usuarioIdAlteracao;
            DataCompra = dataCompra;
            DataAlteracao = dataAlteracao;
            DataLancamento = dataLancamento;
            FlagExcluido = flagExcluido;
            FlagInterface = flagInterface;
            DataInterface = dataInterface;
            UsuarioIdInterface = usuarioIdInterface;
            FlagErroInterface = flagErroInterface;
            DescricaoErroInterface = descricaoErroInterface;
            EmpresaId = empresaId;
            UnidadeId = unidadeId;
        }
    }
}
