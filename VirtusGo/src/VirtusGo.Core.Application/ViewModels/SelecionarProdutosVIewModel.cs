using System.Collections;
using System.Collections.Generic;

namespace VirtusGo.Core.Application.ViewModels
{
    public class SelecionarProdutosVIewModel
    {
        public int PedidoId { get; set; }
        public ICollection<int> Produtos { get; set; }
    }
}