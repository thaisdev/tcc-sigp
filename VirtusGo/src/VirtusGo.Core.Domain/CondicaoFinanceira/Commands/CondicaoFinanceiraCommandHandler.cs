using VirtusGo.Core.Domain.CondicaoFinanceira.Repository;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.CondicaoFinanceira.Commands
{
    public class CondicaoFinanceiraCommandHandler : CommandHandler, IHandler<RegistrarCondicaoFinanceiraCommand>,
        IHandler<AtualizarCondicaoFinanceiraCommand>
    {

        private readonly ICondicaoFinanceiraRepository _condicaoFinanceiraRepository;

        public CondicaoFinanceiraCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarCondicaoFinanceiraCommand message)
        {
            var condicaoFinanceira = CondicaoFinanceira.CondicaoFinanceiraFactory.CondicaoFinanceiraCompleto(message.Id, message.Dias, message.Parcelas);

            if (!condicaoFinanceira.IsValid()) return;

            _condicaoFinanceiraRepository.Adicionar(condicaoFinanceira);

            if (Commit())
            {
            }
        }

        public void Handle(AtualizarCondicaoFinanceiraCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}