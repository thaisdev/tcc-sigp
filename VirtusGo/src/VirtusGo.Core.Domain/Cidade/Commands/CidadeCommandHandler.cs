using VirtusGo.Core.Domain.Cidade.Repository;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Cidade.Commands
{
    public class CidadeCommandHandler : CommandHandler, IHandler<RegistrarCidadeCommand>,
        IHandler<AtualizarCidadeCommand>
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, ICidadeRepository cidadeRepository) : base(
            uow, bus, notifications)
        {
            _cidadeRepository = cidadeRepository;
        }

        public void Handle(RegistrarCidadeCommand message)
        {
            var cidade = Cidade.CidadeFactory.CidadeCompleto(message.Id, message.NomeCidade, message.EstadoId);

            if (!cidade.IsValid()) return;

            _cidadeRepository.Adicionar(cidade);

            if (Commit())
            {
            }
        }

        public void Handle(AtualizarCidadeCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}