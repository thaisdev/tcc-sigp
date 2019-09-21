using System;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Endereco.Commands;
using VirtusGo.Core.Domain.Endereco.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public EnderecoAppService(IEnderecoRepository enderecoRepository, IMapper mapper, IBus bus)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adiconar(EnderecoViewModel model)
        {
            var command = _mapper.Map<RegistrarEnderecoCommand>(model);
            _bus.SendCommand(command);
        }
    }
}