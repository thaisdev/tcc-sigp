namespace VirtusGo.Core.Domain.Produtos.Commands
{
    public class RemoverProdutoCommand : BaseProdutoCommand
    {
        public RemoverProdutoCommand(
            int id,
            string descricao,
            string unidade,
            double valorUnitario,
            int estoque,
            string ncm
            )
        {
            Id = id;
            Descricao = descricao;
            Unidade = unidade;
            ValorUnitario = valorUnitario;
            Estoque = estoque;
            NCM = ncm;
            AggregateId = Id;
        }
    }
}