using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Rota.Repository;

namespace VirtusGo.Core.Domain.Rota.Commands
{
    public class RotaCommandHandler : CommandHandler, IHandler<RegistrarRotaCommand>, IHandler<AtualizarRotaCommand>,
        IHandler<ExcluirRotaCommand>
    {
        private readonly IRotaRepository _rotaRepository;

        public RotaCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IRotaRepository rotaRepository) : base(uow,
            bus, notifications)
        {
            _rotaRepository = rotaRepository;
        }

        public void Handle(RegistrarRotaCommand message)
        {
            var rota = Rota.RotaFactory.RotaCompleta(message.Id, message.EnderecoId);

            _rotaRepository.Adicionar(rota);

            if (Commit())
            {
            }
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