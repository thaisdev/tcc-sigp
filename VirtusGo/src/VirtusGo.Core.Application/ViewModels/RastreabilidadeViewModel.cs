namespace VirtusGo.Core.Application.ViewModels
{
    public class RastreabilidadeViewModel
    {
        public int Id { get; set; }
        public int PedidoVendaId { get; set; }
        public int PedidoCompraId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}