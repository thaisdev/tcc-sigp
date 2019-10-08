using AutoMapper;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Cidade;
using VirtusGo.Core.Domain.Endereco;
using VirtusGo.Core.Domain.Estado;
using VirtusGo.Core.Domain.ItemOrdemCarga;
using VirtusGo.Core.Domain.OrdemCarga;
using VirtusGo.Core.Domain.Veiculo;

namespace VirtusGo.Core.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Veiculo, VeiculoViewModel>();
            CreateMap<OrdemCarga, OrdemCargaViewModel>();
            CreateMap<ItemOrdemCarga, ItemOrdemCargaViewModel>();
        }
    }
}