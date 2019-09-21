using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Rota.Commands
{
    public class RotaCommandHandler : CommandHandler, IHandler<RegistrarRotaCommand>, IHandler<AtualizarRotaCommand>, IHandler<ExcluirRotaCommand>
    {
        public RotaCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarRotaCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarRotaCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(ExcluirRotaCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}