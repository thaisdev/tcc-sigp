using AutoMapper;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Beneficiarios;
using VirtusGo.Core.Domain.Endereco;

namespace VirtusGo.Core.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Beneficiario, BeneficiarioViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
        }
    }
}