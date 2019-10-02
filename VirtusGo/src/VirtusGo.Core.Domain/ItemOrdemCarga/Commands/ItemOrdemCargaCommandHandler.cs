using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.ItemOrdemCarga
{
    public class ItemOrdemCargaCommandHandler : CommandHandler, IHandler<RegistrarItemOrdemCargaCommand>, IHandler<AtualizarItemOrdemCargaCommand>
    {
        public ItemOrdemCargaCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarItemOrdemCargaCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarItemOrdemCargaCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}