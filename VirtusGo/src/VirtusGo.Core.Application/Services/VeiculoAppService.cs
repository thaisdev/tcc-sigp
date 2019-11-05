using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Veiculo;
using VirtusGo.Core.Domain.Veiculo.Commands;
using VirtusGo.Core.Domain.Veiculo.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class VeiculoAppService : IVeiculoAppService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public VeiculoAppService(IVeiculoRepository veiculoRepository, IMapper mapper, IBus bus)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(VeiculoViewModel veiculoViewModel)
        {
            var command = _mapper.Map<RegistrarVeiculoCommand>(veiculoViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(VeiculoViewModel veiculoViewModel)
        {
            var command = _mapper.Map<AtualizarVeiculoCommand>(veiculoViewModel);
            _bus.SendCommand(command);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VeiculoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<Veiculo>, IEnumerable<VeiculoViewModel>>(_veiculoRepository.ObterTodos());
        }

        public IEnumerable<VeiculoViewModel> ObterTodosQueriable()
        {
            return _mapper.Map<IEnumerable<Veiculo>, IEnumerable<VeiculoViewModel>>(_veiculoRepository.ObterTodosQueriable());
        }
    }
}