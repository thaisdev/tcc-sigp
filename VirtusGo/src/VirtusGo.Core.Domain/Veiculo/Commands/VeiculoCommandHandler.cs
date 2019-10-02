using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Veiculo.Commands
{
    public class VeiculoCommandHandler : CommandHandler, IHandler<AtualizarVeiculoCommand>, IHandler<RegistrarVeiculoCommand>
    {
        public VeiculoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarVeiculoCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarVeiculoCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}