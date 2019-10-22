using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.CondicaoFinanceira.Commands
{
    public class CondicaoFinanceiraCommandHandler : CommandHandler, IHandler<RegistrarCondicaoFinanceiraCommand>,
        IHandler<AtualizarCondicaoFinanceiraCommand>
    {

        public CondicaoFinanceiraCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarCondicaoFinanceiraCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarCondicaoFinanceiraCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}