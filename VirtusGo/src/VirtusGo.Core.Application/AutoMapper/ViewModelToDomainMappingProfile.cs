using AutoMapper;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Beneficiarios.Commands;

namespace VirtusGo.Core.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //TODO:Beneficiario

            #region Beneficiario

            CreateMap<BeneficiarioViewModel, RegistrarBeneficiarioCommand>().ConstructUsing(c =>
                new RegistrarBeneficiarioCommand(c.Nome, c.TipPessoa, c.NumeroDocumento, c.Ddd, c.Telefone, c.Email,
                    c.Cep, c.Bairro, c.Endereco, c.Uf, c.Cidade, c.Excluido, c.UsuarioCriacaoId, c.UsuarioAlteracaoId,
                    c.DataCadastro, c.DataAlteracao));

            CreateMap<BeneficiarioViewModel, AtualizarBeneficiarioCommand>().ConstructUsing(c =>
                new AtualizarBeneficiarioCommand(c.Id, c.Nome, c.TipPessoa, c.NumeroDocumento, c.Ddd, c.Telefone,
                    c.Email, c.Cep, c.Bairro, c.Endereco, c.Uf, c.Cidade, c.Excluido, c.UsuarioCriacaoId,
                    c.UsuarioAlteracaoId, c.DataCadastro, c.DataAlteracao));

            CreateMap<BeneficiarioViewModel, DesativarBeneficiarioCommand>().ConstructUsing(c =>
                new DesativarBeneficiarioCommand(c.Id, c.Nome, c.TipPessoa, c.NumeroDocumento, c.Ddd, c.Telefone,
                    c.Email, c.Cep, c.Bairro, c.Endereco, c.Uf, c.Cidade, c.Excluido, c.UsuarioCriacaoId,
                    c.UsuarioAlteracaoId, c.DataCadastro, c.DataAlteracao));

            CreateMap<BeneficiarioViewModel, ExcluirBeneficiarioCommand>()
                .ConstructUsing(c => new ExcluirBeneficiarioCommand(c.Id));

            CreateMap<BeneficiarioViewModel, ReativarBeneficiarioCommand>()
                .ConstructUsing(c => new ReativarBeneficiarioCommand(c.Id));

            #endregion
        }
    }
}