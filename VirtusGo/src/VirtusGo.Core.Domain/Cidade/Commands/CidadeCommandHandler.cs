using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Cidade.Commands
{
    public class CidadeCommandHandler : CommandHandler, IHandler<RegistrarCidadeCommand>, IHandler<AtualizarCidadeCommand>
    {
        public CidadeCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarCidadeCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarCidadeCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}