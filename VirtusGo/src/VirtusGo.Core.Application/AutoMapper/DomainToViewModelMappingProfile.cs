using AutoMapper;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Beneficiarios;
using VirtusGo.Core.Domain.CotacaoPontos;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.EmpresaUsuarios;
using VirtusGo.Core.Domain.Faixas;
using VirtusGo.Core.Domain.Parametro;
using VirtusGo.Core.Domain.Pontuacao;
using VirtusGo.Core.Domain.PontuacaoFococlub;
using VirtusGo.Core.Domain.PontuacaoPdv;
using VirtusGo.Core.Domain.Unidades;
using VirtusGo.Core.Domain.UnidadeUsuarios;

namespace VirtusGo.Core.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Beneficiario, BeneficiarioViewModel>();
            CreateMap<CotacaoPontos, CotacaoPontosViewModel>();
            CreateMap<Empresas, EmpresaViewModel>();
            CreateMap<Unidade, UnidadeViewModel>();
            CreateMap<PontuacaoPDV, PontuacaoPdvViewModel>();
            CreateMap<Faixa, FaixaViewModel>();
            CreateMap<Pontuacao, PontuacaoViewModel>();
            CreateMap<PontuacaoFocoClub, PontuacaoFococlubViewModel>();
            CreateMap<Parametro, ParametrosViewModel>();
            CreateMap<EmpresaUsuarios, EmpresaUsuarioViewModel>();
            CreateMap<UnidadeUsuarios, UnidadeUsuarioViewModel>();
        }
    }
}