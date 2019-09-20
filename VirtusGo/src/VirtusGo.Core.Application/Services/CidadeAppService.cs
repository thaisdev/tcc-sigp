using System;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Cidade.Commands;
using VirtusGo.Core.Domain.Cidade.Repository;
using VirtusGo.Core.Domain.Core.Bus;

namespace VirtusGo.Core.Application.Services
{
    public class CidadeAppService : ICidadeAppService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public CidadeAppService(ICidadeRepository cidadeRepository, IMapper mapper, IBus bus)
        {
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(CidadeViewModel cidadeViewModel)
        {
            var command = _mapper.Map<RegistrarCidadeCommand>(cidadeViewModel);
            _bus.SendCommand(command);
        }
    }
}