﻿using AutoMapper;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Cidade.Commands;
using VirtusGo.Core.Domain.Empresas.Commands;
using VirtusGo.Core.Domain.CondicaoFinanceira.Commands;
using VirtusGo.Core.Domain.Endereco.Commands;
using VirtusGo.Core.Domain.Estado.Commands;
using VirtusGo.Core.Domain.ItemOrdemCarga;
using VirtusGo.Core.Domain.Motoristas.Commands;
using VirtusGo.Core.Domain.OrdemCarga.Commands;
using VirtusGo.Core.Domain.Parceiro.Commands;
using VirtusGo.Core.Domain.Produtos.Commands;
using VirtusGo.Core.Domain.Veiculo.Commands;

namespace VirtusGo.Core.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
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
                new RegistrarVeiculoCommand(c.Id, c.Placa, c.Modelo,c.Cor, c.Marca, c.Renavam, c.ParceiroId));

            CreateMap<VeiculoViewModel, AtualizarVeiculoCommand>().ConstructUsing(c =>
                new AtualizarVeiculoCommand(c.Id, c.Placa, c.Modelo,c.Cor, c.Marca, c.Renavam, c.ParceiroId));

            #endregion
            
            //TODO:Ordem de Carga

            #region OrdemCarga

            CreateMap<OrdemCargaViewModel, RegistrarOrdemCargaCommand>().ConstructUsing(c =>
                new RegistrarOrdemCargaCommand(c.Id, c.DataSaida, c.DataChegada, c.RotaId, c.MotoristaId, c.VeiculoId));

            CreateMap<OrdemCargaViewModel, AtualizarOrdemCargaCommand>().ConstructUsing(c =>
                new AtualizarOrdemCargaCommand(c.Id, c.DataSaida, c.DataChegada, c.RotaId, c.MotoristaId, c.VeiculoId));

            #endregion
            
            //TODO:Item Ordem de Carga

            #region ItemOrdemCarga

            CreateMap<ItemOrdemCargaViewModel, RegistrarItemOrdemCargaCommand>().ConstructUsing(c =>
                new RegistrarItemOrdemCargaCommand(c.Id, c.PedidoId, c.Sequencia));

            CreateMap<ItemOrdemCargaViewModel, AtualizarItemOrdemCargaCommand>().ConstructUsing(c =>
                new AtualizarItemOrdemCargaCommand(c.Id, c.PedidoId, c.Sequencia));

            #endregion

            #region Produto

            CreateMap<ProdutoViewModel, RegistrarProdutoCommand>().ConstructUsing(c =>
                new RegistrarProdutoCommand(c.Id, c.Descricao, c.Unidade, c.ValorUnitario, c.Estoque, c.NCM));

            CreateMap<ProdutoViewModel, AtualizarProdutoCommand>().ConstructUsing(c =>
                new AtualizarProdutoCommand(c.Id, c.Descricao, c.Unidade, c.ValorUnitario, c.Estoque, c.NCM));

            #endregion

            #region Empresa

            CreateMap<EmpresaViewModel, RegistrarEmpresaCommand>().ConstructUsing(c =>
                new RegistrarEmpresaCommand(c.Id, c.Razao, c.CNPJ, c.Inscri, c.EnderecoId));

            CreateMap<EmpresaViewModel, AtualizarEmpresaCommand>().ConstructUsing(c =>
                new AtualizarEmpresaCommand(c.Id, c.Razao, c.CNPJ, c.Inscri, c.EnderecoId));

            #endregion

            #region Motorista

            CreateMap<MotoristaViewModel, RegistrarMotoristaCommand>().ConstructUsing(c =>
                new RegistrarMotoristaCommand(c.Id, c.Nome, c.CPF, c.CategoriaCNH, c.NumeroCNH, c.Telefone,
                    c.DataNascimento, c.DataVencimentoCNH, c.EnderecoId));

            CreateMap<MotoristaViewModel, AtualizarMotoristaCommand>().ConstructUsing(c =>
                new AtualizarMotoristaCommand(c.Id, c.Nome, c.CPF, c.CategoriaCNH, c.NumeroCNH, c.Telefone,
                    c.DataNascimento, c.DataVencimentoCNH, c.EnderecoId));

            #endregion

            #region Parceiro

            CreateMap<ParceiroViewModel, RegistrarParceiroCommand>().ConstructUsing(c =>
                new RegistrarParceiroCommand(c.Id, c.Nome, c.NumeroDocumento, c.EnderecoId, c.Email, c.TipoPessoa, 
                    c.RgInscricaoEstadual, c.Site, c.Telefone));

            CreateMap<ParceiroViewModel, AtualizarParceiroCommand>().ConstructUsing(c =>
                new AtualizarParceiroCommand(c.Id, c.Nome, c.NumeroDocumento, c.EnderecoId, c.Email, c.TipoPessoa, 
                    c.RgInscricaoEstadual, c.Site, c.Telefone));
            
            //TODO: Condicao Financeira

            #region CondicaoFinanceira

            CreateMap<CondicaoFinanceiraViewModel, RegistrarCondicaoFinanceiraCommand>().ConstructUsing(c =>
                new RegistrarCondicaoFinanceiraCommand(c.Id, c.Parcelas, c.Dias));

            CreateMap<CondicaoFinanceiraViewModel, AtualizarCondicaoFinanceiraCommand>().ConstructUsing(c =>
                new AtualizarCondicaoFinanceiraCommand(c.Id, c.Parcelas, c.Dias));

            #endregion
        }
    }
}