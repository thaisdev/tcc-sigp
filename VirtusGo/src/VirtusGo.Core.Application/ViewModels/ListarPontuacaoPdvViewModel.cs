using System;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Unidades;

namespace VirtusGo.Core.Application.ViewModels
{
    public class ListarPontuacaoPdvViewModel
    {
        public int Id { get; set; }
        public double ValorLancamento { get; set; }
        public DateTime DataCompra { get; set; }
        public string Cpf { get; set; }
        public string Operador { get; set; }
        public string Email { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public string FlagInterface { get; set; }
        public DateTime? DataInterface { get; set; }
        public int? UsuarioIdInterface { get; set; }
        public string FlagErroInterface { get; set; }
        public string MensagemErroInterface { get; set; }
        public int UnidadeId { get; set; }
        public int EmpresaId { get; set; }
        public string Empresa { get; set; }
        public string Unidade { get; set; }
        //public virtual Usuario Usuario { get; set; }
    }
}