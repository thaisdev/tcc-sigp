using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Parceiro.Commands
{
    public class ParceiroCommandHandler : CommandHandler, IHandler<RegistrarParceiroCommand>, IHandler<AtualizarParceiroCommand>
    {
        public ParceiroCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarParceiroCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarParceiroCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}