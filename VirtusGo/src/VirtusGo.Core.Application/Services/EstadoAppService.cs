using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Estado;
using VirtusGo.Core.Domain.Estado.Commands;
using VirtusGo.Core.Domain.Estado.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class EstadoAppService : IEstadoAppService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public EstadoAppService(IEstadoRepository estadoRepository, IMapper mapper, IBus bus)
        {
            _estadoRepository = estadoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(EstadoViewModel estadoViewModel)
        {
            var command = _mapper.Map<RegistrarEstadoCommand>(estadoViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(EstadoViewModel estadoViewModel)
        {
            var command = _mapper.Map<AtualizarEstadoCommand>(estadoViewModel);
            _bus.SendCommand(command);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EstadoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoRepository.ObterTodos());
        }
    }
}