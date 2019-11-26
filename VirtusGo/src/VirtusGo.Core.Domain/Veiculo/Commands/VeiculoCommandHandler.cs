using System;
using System.Linq;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Veiculo.Repository;

namespace VirtusGo.Core.Domain.Veiculo.Commands
{
    public class VeiculoCommandHandler : CommandHandler, IHandler<AtualizarVeiculoCommand>,
        IHandler<RegistrarVeiculoCommand>, IHandler<RemoverVeiculoCommand>
    {
        private readonly IBus _bus;
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IVeiculoRepository veiculoRepository) : base(
            uow, bus, notifications)
        {
            _bus = bus;
            _veiculoRepository = veiculoRepository;
        }

        public void Handle(RegistrarVeiculoCommand message)
        {
            var veiculo = Veiculo.VeiculoFactory.VeiculoCompleto(message.Id, message.Placa, message.Modelo, message.Cor,
                message.Marca, message.Renavam, message.ParceiroId);

            if (!ModelValidate(veiculo)) return;

            if (VeiculoExistente(veiculo.Placa))
            {
                _bus.RaiseEvent(new DomainNotification(String.Empty, "Placa já cadastrada!!"));
                return;
            }

            _veiculoRepository.Adicionar(veiculo);

            if (Commit())
            {
            }
        }

        public void Handle(AtualizarVeiculoCommand message)
        {
            var veiculo = Veiculo.VeiculoFactory.VeiculoCompleto(message.Id, message.Placa, message.Modelo, message.Cor,
                message.Marca, message.Renavam, message.ParceiroId);

            if (!ModelValidate(veiculo)) return;

            _veiculoRepository.Atualizar(veiculo);

            if (Commit())
            {
            }
        }

        public void Handle(RemoverVeiculoCommand message)
        {
            var veiculo = Veiculo.VeiculoFactory.VeiculoCompleto(message.Id, message.Placa, message.Modelo, message.Cor,
                message.Marca, message.Renavam, message.ParceiroId);

            _veiculoRepository.Remover(veiculo.Id);

            if (Commit())
            {
            }
        }

        private bool ModelValidate(Veiculo veiculo)
        {
            if (veiculo.IsValid()) return true;

            NotificarValidacoesErro(veiculo.ValidationResult);
            return false;
        }

        private bool VeiculoExistente(string placa)
        {
            var veiculo = _veiculoRepository.Buscar(x => x.Placa == placa).FirstOrDefault();

            return veiculo != null;
        }
    }
}