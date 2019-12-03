using System;

namespace VirtusGo.Core.Application.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public int ParceiroId { get; set; }
        public int VendedorCompradorId { get; set; }
        public int MotoristaId { get; set; }
        public int PagamentoId { get; set; }
        public DateTime DataNegociacaoPedido { get; set; }
        public string TipoPedido { get; set; }
    }
}