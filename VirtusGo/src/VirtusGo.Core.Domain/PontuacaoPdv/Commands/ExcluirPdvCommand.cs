using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.PontuacaoPdv.Commands
{
    public class ExcluirPdvCommand : BasePdvCommand
    {
        public ExcluirPdvCommand(int id, double valorLancamento, DateTime dataCompra,
            string cpf, string operador,
            string email, FlagExcluidoEnum flagExcluido, string flagInterface, DateTime? dataInterface,
            int? usuarioIdInterface, string flagErroInterface, string mensagemErroInterface, int unidadeId,
            int empresaId)
        {
            Id = id;
            ValorLancamento = valorLancamento;
            DataCompra = dataCompra;
            Cpf = cpf;
            Operador = operador;
            Email = email;
            FlagExcluido = flagExcluido;
            FlagInterface = flagInterface;
            DataInterface = dataInterface;
            UsuarioIdInterface = usuarioIdInterface;
            FlagErroInterface = flagErroInterface;
            MensagemErroInterface = mensagemErroInterface;
            UnidadeId = unidadeId;
            EmpresaId = empresaId;

            AggregateId = id;
        }
    }
}