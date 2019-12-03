using System;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Pedido.Repository;

namespace VirtusGo.Core.Domain.Pedido.Commands
{
    public class PedidoCommandHandler : CommandHandler, IHandler<AtualizarPedidoCommand>,
        IHandler<ExcluirPedidoCommand>, IHandler<RegistrarPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public PedidoCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IPedidoRepository pedidoRepository) : base(
            uow, bus, notifications)
        {
            _pedidoRepository = pedidoRepository;
            _bus = bus;
        }

        public void Handle(AtualizarPedidoCommand message)
        {
            var pedido = Pedido.PedidoFactory.PedidoCompleto(message.Id, message.ParceiroId,
                message.VendedorCompradorId,
                message.MotoristaId, message.PagamentoId, message.DataNegociacaoPedido, message.TipoPedido);

            _pedidoRepository.Adicionar(pedido);

            if (Commit())
            {
                
            }
        }

        public void Handle(ExcluirPedidoCommand message)
        {
            _pedidoRepository.Remover(message.Id);

            if (Commit())
            {
            }
        }

        public void Handle(RegistrarPedidoCommand message)
        {
            var pedido = Pedido.PedidoFactory.PedidoCompleto(message.Id, message.ParceiroId,
                message.VendedorCompradorId,
                message.MotoristaId, message.PagamentoId, message.DataNegociacaoPedido,
                message.TipoPedido);

            _pedidoRepository.Adicionar(pedido);

            if (Commit())
            {
                
            }
        }
    }
}