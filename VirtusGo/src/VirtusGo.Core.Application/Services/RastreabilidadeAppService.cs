using AutoMapper;
using System;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Rastreabilidade.Commands;
using VirtusGo.Core.Domain.Rastreabilidade.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class RastreabilidadeAppService : IRastreabilidadeAppService
    {
        private readonly IRastreabilidadeRepository _rastreabilidadeRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public RastreabilidadeAppService(IRastreabilidadeRepository rastreabilidadeRepository, IMapper mapper, IBus bus)
        {
            _rastreabilidadeRepository = rastreabilidadeRepository;
            _mapper = mapper;
            _bus = bus;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(RastreabilidadeViewModel rastreabilidadeViewModel)
        {
            var command = _mapper.Map<RegistrarRastreabilidadeCommand>(rastreabilidadeViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(RastreabilidadeViewModel rastreabilidadeViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}