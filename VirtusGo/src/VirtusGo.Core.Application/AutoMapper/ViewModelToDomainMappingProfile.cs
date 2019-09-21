using AutoMapper;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Beneficiarios.Commands;
using VirtusGo.Core.Domain.Cidade.Commands;
using VirtusGo.Core.Domain.Endereco.Commands;
using VirtusGo.Core.Domain.Estado.Commands;
using VirtusGo.Core.Domain.Veiculo.Commands;

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

            //TODO:Cidade

            #region Cidade

            CreateMap<CidadeViewModel, RegistrarCidadeCommand>()
                .ConstructUsing(c => new RegistrarCidadeCommand(c.Id, c.NomeCidade, c.EstadoId));
            CreateMap<CidadeViewModel, AtualizarCidadeCommand>()
                .ConstructUsing(c => new AtualizarCidadeCommand(c.Id, c.NomeCidade, c.EstadoId));

            #endregion
            
            //TODO:Estado

            #region Estado

            CreateMap<EstadoViewModel, RegistrarEstadoCommand>()
                .ConstructUsing(c => new RegistrarEstadoCommand(c.Id, c.NomeEstado, c.SiglaEstado));
            CreateMap<EstadoViewModel, AtualizarEstadoCommand>()
                .ConstructUsing(c => new AtualizarEstadoCommand(c.Id, c.NomeEstado, c.SiglaEstado));

            #endregion

            //TODO:Endereco

            #region Endereco

            CreateMap<EnderecoViewModel, RegistrarEnderecoCommand>().ConstructUsing(c =>
                new RegistrarEnderecoCommand(c.Id, c.Logradouro, c.Numero, c.Bairro, c.CidadeId, c.Cep));

            CreateMap<EnderecoViewModel, AtualizarEnderecoCommand>().ConstructUsing(c =>
                new AtualizarEnderecoCommand(c.Id, c.Logradouro, c.Numero, c.Bairro, c.CidadeId, c.Cep));

            #endregion
            
            //TODO:Veiculo

            #region Veiculo

            CreateMap<VeiculoViewModel, RegistrarVeiculoCommand>().ConstructUsing(c =>
                new RegistrarVeiculoCommand(c.Id, c.Placa, c.Modelo,c.Cor, c.Marca, c.Renavam));

            CreateMap<VeiculoViewModel, AtualizarVeiculoCommand>().ConstructUsing(c =>
                new AtualizarVeiculoCommand(c.Id, c.Placa, c.Modelo,c.Cor, c.Marca, c.Renavam));

            #endregion
        }
    }
}