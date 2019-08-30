using System;
using VirtusGo.Core.Domain.Beneficiarios;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Unidades;

namespace VirtusGo.Core.Domain.Pontuacao
{
    public class Pontuacao : Entity<Pontuacao>
    {

        public Pontuacao(
            int id,
            int beneficiarioId,
            double valorLancamento,
            int usuarioIdCriacao,
            int usuarioIdAlteracao,
            DateTime dataCompra,
            DateTime dataLancamento,
            DateTime dataAlteracao,
            FlagExcluidoEnum flagExcluido,
            string flagInterface,
            DateTime dataInterface,
            int usuarioIdInterface,
            string flagErroInterface,
            string descricaoErroInterface,
            int empresaId,
            int unidadeId
            )
        {
            Id = id;
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

        public Pontuacao() { }

        //public int PontuacaoId { get; set; }
        public int BeneficiarioId { get; set; }
        public virtual Beneficiario Beneficiarios { get; set; }
        public double ValorLancamento { get; set; }
        public int UsuarioIdCriacao { get; set; }
        public int? UsuarioIdAlteracao { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public string FlagInterface { get; set; }
        public DateTime? DataInterface { get; set; }
        public int? UsuarioIdInterface { get; set; }
        public string FlagErroInterface { get; set; }
        public string DescricaoErroInterface { get; set; }
        public int EmpresaId { get; set; }
        public int? UnidadeId { get; set; }
        public virtual Unidade Unidade { get; set; }

        
        public virtual Empresas Empresa { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidationResult = Validate(this);
        }
        #endregion

        public static class PontuacaoFactory
        {
            public static Pontuacao PontuacaoCompleto(int id,
            int beneficiarioId,
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
                var pontuacao = new Pontuacao()
                {
                    Id = id,
                    BeneficiarioId = beneficiarioId,
                    ValorLancamento = valorLancamento,
                    UsuarioIdCriacao = usuarioIdCriacao,
                    UsuarioIdAlteracao = usuarioIdAlteracao,
                    DataCompra = dataCompra,
                    DataAlteracao = dataAlteracao,
                    DataLancamento = dataLancamento,
                    FlagExcluido = flagExcluido,
                    FlagInterface = flagInterface,
                    DataInterface = dataInterface,
                    UsuarioIdInterface = usuarioIdInterface,
                    FlagErroInterface = flagErroInterface,
                    DescricaoErroInterface = descricaoErroInterface,
                    EmpresaId = empresaId,
                    UnidadeId = unidadeId
                };
                return pontuacao;
            }
        }

    }
}
