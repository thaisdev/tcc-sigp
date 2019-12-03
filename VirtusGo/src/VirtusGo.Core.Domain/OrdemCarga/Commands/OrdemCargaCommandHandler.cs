using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.OrdemCarga.Repository;

namespace VirtusGo.Core.Domain.OrdemCarga.Commands
{
    public class OrdemCargaCommandHandler : CommandHandler, IHandler<RegistrarOrdemCargaCommand>,
        IHandler<AtualizarOrdemCargaCommand>, IHandler<ExcluirOrdemCargaCommand>
    {
        private readonly IOrdemCargaRepository _ordemCargaRepository;

        public OrdemCargaCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IOrdemCargaRepository ordemCargaRepository) :
            base(uow, bus, notifications)
        {
            _ordemCargaRepository = ordemCargaRepository;
        }

        public OrdemCargaCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }

        public void Handle(RegistrarOrdemCargaCommand message)
        {
            var ordem = OrdemCarga.OrdemCargaFactory.OrdemCargaCompleto(message.Id, message.DataSaida,
                message.DataChegada, message.RotaId, message.MotoristaId, message.VeiculoId);

            if (!ordem.IsValid()) return;

            _ordemCargaRepository.Adicionar(ordem);

            if (Commit())
            {
            }
        }

        public void Handle(AtualizarOrdemCargaCommand message)
        {
            var ordem = OrdemCarga.OrdemCargaFactory.OrdemCargaCompleto(message.Id, message.DataSaida,
                message.DataChegada, message.RotaId, message.MotoristaId, message.VeiculoId);

            if (!ordem.IsValid()) return;

            _ordemCargaRepository.Atualizar(ordem);

            if (Commit())
            {
            }
        }

        public void Handle(ExcluirOrdemCargaCommand message)
        {
            _ordemCargaRepository.Remover(message.Id);

            if (Commit())
            {
            }
        }
    }
}