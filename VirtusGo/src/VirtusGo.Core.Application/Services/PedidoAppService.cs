using AutoMapper;
using System;
using System.Collections.Generic;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Pedido;
using VirtusGo.Core.Domain.Pedido.Commands;
using VirtusGo.Core.Domain.Pedido.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public PedidoAppService(IPedidoRepository pedidoRepository, IMapper mapper, IBus bus)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(PedidoViewModel pedidoViewModel)
        {
            var command = _mapper.Map<RegistrarPedidoCommand>(pedidoViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(PedidoViewModel pedidoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PedidoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_pedidoRepository.ObterTodos());
        }

        public IEnumerable<PedidoViewModel> ObterTodosQueriable()
        {
            return _mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(
                _pedidoRepository.ObterTodosQueriable());
        }
    }
}