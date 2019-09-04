using AutoMapper;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Beneficiarios;

namespace VirtusGo.Core.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Beneficiario, BeneficiarioViewModel>();
        }
    }
}