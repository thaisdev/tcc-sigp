using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Parceiro.Repository;

namespace VirtusGo.Core.Domain.Parceiro.Commands
{
    public class ParceiroCommandHandler : CommandHandler, IHandler<RegistrarParceiroCommand>,
        IHandler<AtualizarParceiroCommand>, IHandler<ExcluirParceiroCommand>
    {
        private readonly IParceiroRepository _parceiroRepository;

        public ParceiroCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IParceiroRepository parceiroRepository) :
            base(uow, bus, notifications)
        {
            _parceiroRepository = parceiroRepository;
        }

        public void Handle(RegistrarParceiroCommand message)
        {
            var parceiro = Parceiro.ParceiroFactory.ParceiroCompleto(message.Id, message.Nome, message.NumeroDocumento,
                message.EnderecoId, message.Email, message.TipoPessoa, message.RgInscricaoEstadual, message.Site,
                message.Telefone);

            if (!ModelValidate(parceiro)) return;

            _parceiroRepository.Adicionar(parceiro);

            if (Commit())
            {
            }
        }

        public void Handle(AtualizarParceiroCommand message)
        {
            var parceiro = Parceiro.ParceiroFactory.ParceiroCompleto(message.Id, message.Nome, message.NumeroDocumento,
                message.EnderecoId, message.Email, message.TipoPessoa, message.RgInscricaoEstadual, message.Site,
                message.Telefone);

            if (!ModelValidate(parceiro)) return;

            _parceiroRepository.Atualizar(parceiro);

            if (Commit())
            {
            }
        }

        private bool ModelValidate(Parceiro parceiro)
        {
            if (parceiro.IsValid()) return true;

            NotificarValidacoesErro(parceiro.ValidationResult);
            return false;
        }

        public void Handle(ExcluirParceiroCommand message)
        {
            _parceiroRepository.Remover(message.Id);

            if (Commit())
            {
                
            }
        }
    }
}