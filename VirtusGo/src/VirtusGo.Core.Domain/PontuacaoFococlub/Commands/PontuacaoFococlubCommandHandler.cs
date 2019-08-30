using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.PontuacaoFococlub.Repository;
using VirtusGo.Core.Domain.Validations.Documento;

namespace VirtusGo.Core.Domain.PontuacaoFocoClub.Commands
{
    public class PontuacaoFococlubCommandHandler : CommandHandler, IHandler<RegistrarPontuacaoFococlubCommand>
    {
        private readonly IPontuacaoFococlubRepository _pontuacaoFococlubRepository;
        private readonly IBus _bus;

        public PontuacaoFococlubCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            IPontuacaoFococlubRepository pontuacaoFococlubRepository) : base(uow, bus, notifications)
        {
            _bus = bus;
            _pontuacaoFococlubRepository = pontuacaoFococlubRepository;
        }

        public void Handle(RegistrarPontuacaoFococlubCommand message)
        {
            var pontuacaoFococlub = PontuacaoFococlub.PontuacaoFocoClub.PontuacaoFococlubFactory.PontuacaoCompleto(
                message.Id,
                message.Email, message.ValorPontos, message.BeneficiarioId, message.PontuacaoIdGo, message.EmpresaId,
                message.UnidadeId, message.DataCompra, message.Datalancamento, message.DataInterface);

            if (!pontuacaoFococlub.IsValid())
            {
                foreach (var item in pontuacaoFococlub.ValidationResult.Errors)
                {
                    _bus.RaiseEvent(new DomainNotification(message.MessageType, item.ErrorMessage));
                }

                return;
            }

            if (!EmailValidation.Validate(pontuacaoFococlub.Email))
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Email está inválido"));
                return;
            }

            _pontuacaoFococlubRepository.Adicionar(pontuacaoFococlub);
            
        }
    }
}