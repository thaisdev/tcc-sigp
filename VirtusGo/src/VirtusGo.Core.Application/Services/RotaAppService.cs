using System;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Rota.Commands;
using VirtusGo.Core.Domain.Rota.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class RotaAppService : IRotaAppService
    {
        private readonly IRotaRepository _rotaRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public RotaAppService(IRotaRepository rotaRepository, IMapper mapper, IBus bus)
        {
            _rotaRepository = rotaRepository;
            _mapper = mapper;
            _bus = bus;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(RotaViewModel rotaViewModel)
        {
            var command = _mapper.Map<RegistrarRotaCommand>(rotaViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(RotaViewModel rotaViewModel)
        {
            var command = _mapper.Map<AtualizarRotaCommand>(rotaViewModel);
            _bus.SendCommand(command);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}