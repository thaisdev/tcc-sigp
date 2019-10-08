using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.ItensPedidos.Repository;

namespace VirtusGo.Core.Domain.ItensPedidos.Commands
{
    public class ItensPedidoCommandHandler : CommandHandler, IHandler<AtualizarItensPedidoCommand>, 
        IHandler<ExcluirItensPedidoCommand>, IHandler<RegistrarItensPedidoCommand>
    {
        private readonly IItensPedidoRepository _itensPedidoRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public ItensPedidoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IItensPedidoRepository itensPedidoRepository) : base(uow, bus, notifications)
        {
            _itensPedidoRepository = itensPedidoRepository;
            _bus = bus;
        }

        public void Handle(AtualizarItensPedidoCommand message)
        {
            var itensPedido = ItensPedido.ItensPedidoFactory.ItensPedidoCompleto(message.Id,
                message.ProdutoId, message.ValorUnitario, message.ValorTotal, message.Quantidade);

            _itensPedidoRepository.Adicionar(itensPedido);
        }

        public void Handle(ExcluirItensPedidoCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(RegistrarItensPedidoCommand message)
        {
            var itensPedido = ItensPedido.ItensPedidoFactory.ItensPedidoCompleto(message.Id,
                message.ProdutoId, message.ValorUnitario, message.ValorTotal, message.Quantidade);

            _itensPedidoRepository.Adicionar(itensPedido);
        }
    }
}
