using System;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.PontuacaoFocoClub.Commands
{
    public class BasePontuacaoFocoClubCommand : Command
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public double ValorPontos { get; set; }
        public int BeneficiarioId { get; set; }
        public int PontuacaoIdGo { get; set; }
        public int EmpresaId { get; set; }
        public int? UnidadeId { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime Datalancamento { get; set; }
        public DateTime DataInterface { get; set; }
    }
}