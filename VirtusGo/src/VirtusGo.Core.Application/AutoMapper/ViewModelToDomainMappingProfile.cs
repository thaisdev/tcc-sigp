using AutoMapper;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Beneficiarios.Commands;
using VirtusGo.Core.Domain.CotacaoPontos.Commands;
using VirtusGo.Core.Domain.Empresa.Commands;
using VirtusGo.Core.Domain.EmpresaUsuarios.Command;
using VirtusGo.Core.Domain.Faixas.Commands;
using VirtusGo.Core.Domain.Parametro.Command;
using VirtusGo.Core.Domain.Pontuacao.Commands;
using VirtusGo.Core.Domain.PontuacaoFocoClub.Commands;
using VirtusGo.Core.Domain.PontuacaoPdv.Commands;
using VirtusGo.Core.Domain.Unidades.Commands;
using VirtusGo.Core.Domain.UnidadeUsuarios.Commands;

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

            //TODO:Empresa

            #region Empresa

            CreateMap<EmpresaViewModel, RegistrarEmpresaCommand>().ConstructUsing(c =>
                new RegistrarEmpresaCommand(c.RazaoSocial, c.NomeFantasia, c.NumeroDocumento, c.Bloqueado, c.Excluido,
                    c.Email, c.Email, c.Email2, c.Email3, c.Bairro, c.Endereco, c.Latitude, c.Longitude, c.Ramo,
                    c.ProfissionalLiberal, c.Plano, c.Uf,
                    c.Cidade, c.Contato, c.Contato2,
                    c.Ddd, c.Telefone, c.Ddd2, c.Telefone2, c.Ddd3, c.Telefone3, c.QuantidadeFilial,
                    c.DiasParaExpiracaoPontos, c.ValorComissãoGeral, c.PorcentagemPadraoPontos, c.DataCriacao,
                    c.DataAlteracao, c.UsuarioIdCriacao, c.UsuarioIdAlteracao));

            CreateMap<EmpresaViewModel, AtualizarEmpresaCommand>().ConstructUsing(c =>
                new AtualizarEmpresaCommand(c.RazaoSocial, c.NomeFantasia, c.NumeroDocumento, c.Bloqueado, c.Excluido,
                    c.Email, c.Email, c.Email2, c.Email3, c.Bairro, c.Endereco, c.Latitude, c.Longitude, c.Ramo,
                    c.ProfissionalLiberal, c.Plano, c.Uf,
                    c.Cidade, c.Contato, c.Contato2,
                    c.Ddd, c.Telefone, c.Ddd2, c.Telefone2, c.Ddd3, c.Telefone3, c.QuantidadeFilial,
                    c.DiasParaExpiracaoPontos, c.ValorComissãoGeral, c.PorcentagemPadraoPontos, c.DataCriacao,
                    c.DataAlteracao, c.UsuarioIdCriacao, c.UsuarioIdAlteracao));

            CreateMap<EmpresaViewModel, ExcluirEmpresaCommand>().ConstructUsing(c => new ExcluirEmpresaCommand(c.Id));

            CreateMap<EmpresaViewModel, DesativarEmpresaCommand>()
                .ConstructUsing(c => new DesativarEmpresaCommand(c.Id));

            CreateMap<EmpresaViewModel, ReativarEmpresaCommand>().ConstructUsing(c => new ReativarEmpresaCommand(c.Id));

            #endregion

            //TODO:Unidade

            #region Unidade

            CreateMap<UnidadeViewModel, RegistrarUnidadeCommand>().ConstructUsing(c =>
                new RegistrarUnidadeCommand(c.RazaoSocial, c.Fantasia, c.Documento, c.Email, c.Ddd, c.Telefone, c.Cep,
                    c.Bairro, c.Endereco, c.Latitude, c.Longitude, c.Ramo, c.Uf, c.Cidade, c.FlagBloqueado,
                    c.FlagExcluido, c.UsuarioIdCriador,
                    c.UsuarioIdAltera, c.EmpresaId, c.DataCriacao, c.DataAlteracao, c.NumeroDiasParaExpiracaoPontos,
                    c.ComissaoGeral, c.ValorPorcentagemGeralPontos));

            CreateMap<UnidadeViewModel, AtualizarUnidadeCommand>().ConstructUsing(c =>
                new AtualizarUnidadeCommand(c.RazaoSocial, c.Fantasia, c.Documento, c.Email, c.Ddd, c.Telefone, c.Cep,
                    c.Bairro, c.Endereco, c.Latitude, c.Longitude, c.Ramo, c.Uf, c.Cidade, c.FlagBloqueado,
                    c.FlagExcluido, c.UsuarioIdCriador,
                    c.UsuarioIdAltera, c.EmpresaId, c.DataCriacao, c.DataAlteracao, c.NumeroDiasParaExpiracaoPontos,
                    c.ComissaoGeral, c.ValorPorcentagemGeralPontos));

            CreateMap<UnidadeViewModel, DesativarUnidadeCommand>()
                .ConstructUsing(c => new DesativarUnidadeCommand(c.Id));

            CreateMap<UnidadeViewModel, DesativarUnidadeCommand>()
                .ConstructUsing(c => new DesativarUnidadeCommand(c.Id));

            CreateMap<UnidadeViewModel, ReativarUnidadeCommand>().ConstructUsing(c => new ReativarUnidadeCommand(c.Id));

            #endregion

            //TODO:Pontuacao

            #region Pontuacao

            CreateMap<PontuacaoViewModel, RegistrarPontuacaoCommand>().ConstructUsing(c =>
                new RegistrarPontuacaoCommand(c.Id, c.BeneficiarioId, c.ValorLancamento, c.UsuarioIdCriacao,
                    c.UsuarioIdAlteracao, c.DataCompra, c.DataLancamento, c.DataAlteracao, c.FlagExcluido,
                    c.FlagInterface, c.DataInterface, c.UsuarioIdInterface, c.FlagErroInterface,
                    c.DescricaoErroInterface, c.EmpresaId, c.UnidadeId));

            CreateMap<PontuacaoViewModel, DesativarPontuacaoCommand>()
                .ConstructUsing(c => new DesativarPontuacaoCommand(c.Id));

            CreateMap<PontuacaoViewModel, ExcluirPontuacaoCommand>()
                .ConstructUsing(c => new ExcluirPontuacaoCommand(c.Id));

            #endregion

            //TODO:PontuacaoFococlub

            #region PontuacaoFococlub

            CreateMap<PontuacaoFococlubViewModel, RegistrarPontuacaoFococlubCommand>().ConstructUsing(c =>
                new RegistrarPontuacaoFococlubCommand(c.Id, c.Email, c.ValorPontos, c.BeneficiarioId, c.PontuacaoIdGo,
                    c.EmpresaId, c.UnidadeId, c.DataCompra, c.Datalancamento, c.DataInterface));

            #endregion

            //TODO:CotacaoPontos

            #region Cotacao

            CreateMap<CotacaoPontosViewModel, RegistrarCotacaoPontosCommand>()
                .ConvertUsing(c => new RegistrarCotacaoPontosCommand(c.Valor, c.DataVigencia, c.FlagExcluido,
                    c.DataCriacao, c.DataAlteracao, c.UsuarioIdCriacao, c.UsuarioIdAlteracao));

            #endregion

            //TODO:Parametro

            #region Parametro

            CreateMap<ParametrosViewModel, AtualizarParametroCommand>()
                .ConstructUsing(c => new AtualizarParametroCommand(c.Id, c.DiasParaExpiracaoPontos,
                    c.ValorComissaoGeral, c.ValorPorcentagemGeralPontosFaixa, c.FlagExcluido, c.DataCriacao,
                    c.DataAlteracao, c.UsuarioIdCriacao,
                    c.UsuarioIdAlteracao));

            #endregion

            //TODO:Faixa

            #region Faixa

            CreateMap<FaixaViewModel, RegistrarFaixaCommand>().ConvertUsing(c =>
                new RegistrarFaixaCommand(c.ValorDe, c.ValorAte, c.ValorPorcentagem, c.FlagExcluido, c.DataCriacao,
                    c.DataAlteracao, c.EmpresaId, c.UnidadeId, c.UsuarioIdCriacao, c.UsuarioIdAltera));

            CreateMap<FaixaViewModel, AtualizarFaixaCommand>().ConvertUsing(c =>
                new AtualizarFaixaCommand(c.Id, c.ValorDe, c.ValorAte, c.ValorPorcentagem, c.FlagExcluido,
                    c.DataCriacao,
                    c.DataAlteracao, c.EmpresaId, c.UnidadeId, c.UsuarioIdCriacao, c.UsuarioIdAltera));

            CreateMap<FaixaViewModel, ExcluirFaixaCommand>().ConstructUsing(c => new ExcluirFaixaCommand(c.Id));

            #endregion

            //TODO:PDV

            #region PontuacaoPDV

            CreateMap<PontuacaoPdvViewModel, ExcluirPdvCommand>().ConstructUsing(c => new ExcluirPdvCommand(c.Id,
                c.ValorLancamento, c.DataCompra, c.Cpf, c.Operador, c.Email, c.FlagExcluido, c.FlagInterface,
                c.DataInterface, c.UsuarioIdInterface, c.FlagErroInterface, c.MensagemErroInterface, c.UnidadeId,
                c.EmpresaId));

            CreateMap<PontuacaoPdvViewModel, AprovarPdvCommand>().ConstructUsing(c => new AprovarPdvCommand(c.Id,
                c.ValorLancamento, c.DataCompra, c.Cpf, c.Operador, c.Email, c.FlagExcluido, c.FlagInterface,
                c.DataInterface, c.UsuarioIdInterface, c.FlagErroInterface, c.MensagemErroInterface, c.UnidadeId,
                c.EmpresaId));

            #endregion
            
            //TODO:EmpresaUsuario

            #region EmpresaUsuarios

            CreateMap<EmpresaUsuarioViewModel, RegistrarEmpresaUsuariosCommand>().ConstructUsing(c =>
                new RegistrarEmpresaUsuariosCommand(c.Id, c.UsuarioId, c.EmpresaId));

            #endregion

            //TODO:UnidadeUsuarios

            #region UnidadeUsuarios

            CreateMap<UnidadeUsuarioViewModel, RegistrarUnidadeUsuariosCommand>().ConstructUsing(c =>
                new RegistrarUnidadeUsuariosCommand(c.Id, c.UsuarioId, c.UnidadeId));

            #endregion
        }
    }
}