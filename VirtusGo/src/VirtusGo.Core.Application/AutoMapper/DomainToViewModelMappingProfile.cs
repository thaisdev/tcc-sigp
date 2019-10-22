using AutoMapper;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Cidade;
using VirtusGo.Core.Domain.CondicaoFinanceira;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Endereco;
using VirtusGo.Core.Domain.EnderecoEstoque;
using VirtusGo.Core.Domain.Estado;
using VirtusGo.Core.Domain.ItemOrdemCarga;
using VirtusGo.Core.Domain.ItensPedidos;
using VirtusGo.Core.Domain.Motoristas;
using VirtusGo.Core.Domain.OrdemCarga;
using VirtusGo.Core.Domain.Parceiro;
using VirtusGo.Core.Domain.Pedido;
using VirtusGo.Core.Domain.Produtos;
using VirtusGo.Core.Domain.Rastreabilidade;
using VirtusGo.Core.Domain.Rota;
using VirtusGo.Core.Domain.Veiculo;

namespace VirtusGo.Core.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<Empresa, EmpresaViewModel>();
            CreateMap<EnderecoEstoque, EnderecoEstoqueViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<ItemOrdemCarga, ItemOrdemCargaViewModel>();
            CreateMap<ItensPedido, ItensPedidoViewModel>();
            CreateMap<Motorista, MotoristaViewModel>();
            CreateMap<OrdemCarga, OrdemCargaViewModel>();
            CreateMap<Parceiro, ParceiroViewModel>();
            CreateMap<Pedido, PedidoViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Rastreabilidade, RastreabilidadeViewModel>();
            CreateMap<Rota, RotaViewModel>();
            CreateMap<Veiculo, VeiculoViewModel>();
            CreateMap<CondicaoFinanceira, CondicaoFinanceiraViewModel>();
        }
    }
}