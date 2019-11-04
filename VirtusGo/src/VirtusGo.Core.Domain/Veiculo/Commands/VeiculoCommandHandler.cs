using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Veiculo.Repository;

namespace VirtusGo.Core.Domain.Veiculo.Commands
{
    public class VeiculoCommandHandler : CommandHandler, IHandler<AtualizarVeiculoCommand>,
        IHandler<RegistrarVeiculoCommand>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IVeiculoRepository veiculoRepository) : base(
            uow, bus, notifications)
        {
            _veiculoRepository = veiculoRepository;
        }

        public void Handle(RegistrarVeiculoCommand message)
        {
            var veiculo = Veiculo.VeiculoFactory.VeiculoCompleto(message.Id, message.Placa, message.Modelo, message.Cor,
                message.Marca, message.Renavam, message.ParceiroId);

            if (!veiculo.IsValid()) return;

            _veiculoRepository.Adicionar(veiculo);

            if (Commit())
            {
            }
        }

        public void Handle(AtualizarVeiculoCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}