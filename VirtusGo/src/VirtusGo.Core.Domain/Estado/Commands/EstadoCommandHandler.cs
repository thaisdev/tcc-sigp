using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Estado.Commands
{
    public class EstadoCommandHandler : CommandHandler, IHandler<RegistrarEstadoCommand>,
        IHandler<AtualizarEstadoCommand>
    {
        public EstadoCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarEstadoCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarEstadoCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}