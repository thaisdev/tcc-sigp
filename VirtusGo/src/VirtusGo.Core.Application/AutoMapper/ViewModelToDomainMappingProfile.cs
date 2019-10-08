using AutoMapper;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Cidade.Commands;
using VirtusGo.Core.Domain.Endereco.Commands;
using VirtusGo.Core.Domain.Estado.Commands;
using VirtusGo.Core.Domain.ItemOrdemCarga;
using VirtusGo.Core.Domain.OrdemCarga.Commands;
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
                new RegistrarItemOrdemCargaCommand(c.Id, c.OrdemCargaId, c.PedidoId, c.Sequencia));

            CreateMap<ItemOrdemCargaViewModel, AtualizarItemOrdemCargaCommand>().ConstructUsing(c =>
                new AtualizarItemOrdemCargaCommand(c.Id, c.OrdemCargaId, c.PedidoId, c.Sequencia));

            #endregion
        }
    }
}