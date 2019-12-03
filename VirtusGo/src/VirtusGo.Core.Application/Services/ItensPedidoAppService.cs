using AutoMapper;
using System;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.ItensPedidos.Commands;
using VirtusGo.Core.Domain.ItensPedidos.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class ItensPedidoAppService : IItensPedidoAppService
    {
        private readonly IItensPedidoRepository _itensPedidoRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public ItensPedidoAppService(IItensPedidoRepository itensPedidoRepository, IMapper mapper, IBus bus)
        {
            _itensPedidoRepository = itensPedidoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(ItensPedidoViewModel itensPedidoViewModel)
        {
            var command = _mapper.Map<RegistrarItensPedidoCommand>(itensPedidoViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(ItensPedidoViewModel itensPedidoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}