using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.OrdemCarga.Commands
{
    public class OrdemCargaCommandHandler : CommandHandler, IHandler<RegistrarOrdemCargaCommand>, IHandler<AtualizarOrdemCargaCommand>
    {
        public OrdemCargaCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarOrdemCargaCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarOrdemCargaCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}