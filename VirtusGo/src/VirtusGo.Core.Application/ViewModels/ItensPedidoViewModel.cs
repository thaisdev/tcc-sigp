namespace VirtusGo.Core.Application.ViewModels
{
    public class ItensPedidoViewModel
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        public int Quantidade { get; private set; }
    }
}