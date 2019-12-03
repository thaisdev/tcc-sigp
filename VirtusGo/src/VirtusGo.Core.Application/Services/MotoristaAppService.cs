using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Motoristas;
using VirtusGo.Core.Domain.Motoristas.Commands;
using VirtusGo.Core.Domain.Motoristas.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class MotoristaAppService : IMotoristaAppService
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public MotoristaAppService(IMotoristaRepository motoristaRepository, IMapper mapper, IBus bus)
        {
            _motoristaRepository = motoristaRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(MotoristaViewModel motoristaViewModel)
        {
            var command = _mapper.Map<RegistrarMotoristaCommand>(motoristaViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(MotoristaViewModel motoristaViewModel)
        {
            var command = _mapper.Map<AtualizarMotoristaCommand>(motoristaViewModel);
            _bus.SendCommand(command);
        }

        public void Excluir(int id)
        {
            var motorista = _mapper.Map<Motorista, MotoristaViewModel>(_motoristaRepository.ObterPorId(id));
            var command = _mapper.Map<ExcluirMotoristaCommand>(motorista);
            _bus.SendCommand(command);
        }

        public IEnumerable<MotoristaViewModel> ObterTodosQueriable()
        {
            return _mapper.Map<IEnumerable<Motorista>, IEnumerable<MotoristaViewModel>>(_motoristaRepository
                .ObterTodosQueriable());
        }

        public IEnumerable<MotoristaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<Motorista>, IEnumerable<MotoristaViewModel>>(
                _motoristaRepository.ObterTodos());
        }
    }
}