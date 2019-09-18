using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Endereco.Commands
{
    public class EnderecoCommandHandler : CommandHandler, IHandler<RegistrarEnderecoCommand>, IHandler<AtualizarEnderecoCommand>
    {
        public EnderecoCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarEnderecoCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarEnderecoCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}