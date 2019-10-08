namespace VirtusGo.Core.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public int ValorUnitario { get; set; }
        public int Estoque { get; set; }
        public string NCM { get; set; }
    }
}