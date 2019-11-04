using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Estado.Repository;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Estado.Commands
{
    public class EstadoCommandHandler : CommandHandler, IHandler<RegistrarEstadoCommand>,
        IHandler<AtualizarEstadoCommand>
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IEstadoRepository estadoRepository) : base(
            uow, bus, notifications)
        {
            _estadoRepository = estadoRepository;
        }

        public void Handle(RegistrarEstadoCommand message)
        {
            var estado = Estado.EstadoFactory.EstadoCompleto(message.Id, message.NomeEstado, message.SiglaEstado);

            if (!estado.IsValid()) return;

            _estadoRepository.Adicionar(estado);

            if (Commit())
            {
            }
        }

        public void Handle(AtualizarEstadoCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}