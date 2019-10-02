using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Pedidos.Repository;

namespace VirtusGo.Core.Domain.Pedidos.Commands
{
    public class PedidoCommandHandler : CommandHandler, IHandler<AtualizarPedidoCommand>,
        IHandler<ExcluirPedidoCommand>, IHandler<RegistrarPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public PedidoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IPedidoRepository pedidoRepository) : base(uow, bus, notifications)
        {
            _pedidoRepository = pedidoRepository;
            _bus = bus;
        }

        public void Handle(AtualizarPedidoCommand message)
        {
            var pedido = Pedido.PedidoFactory.PedidoCompleto(message.Id, message.ParceiroId, message.VendedorCompradorId,
                message.EmpresaId, message.MotoristaId, message.UsuarioId, message.DataNegociacaoPedido, message.TipoPedido);

            _pedidoRepository.Adicionar(pedido);
        }

        public void Handle(ExcluirPedidoCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(RegistrarPedidoCommand message)
        {
            var pedido = Pedido.PedidoFactory.PedidoCompleto(message.Id, message.ParceiroId, message.VendedorCompradorId,
                message.EmpresaId, message.MotoristaId, message.UsuarioId, message.DataNegociacaoPedido, message.TipoPedido);

            _pedidoRepository.Adicionar(pedido);
        }
    }
}
