using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Endereco.Repository;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Endereco.Commands
{
    public class EnderecoCommandHandler : CommandHandler, IHandler<RegistrarEnderecoCommand>,
        IHandler<AtualizarEnderecoCommand>
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IEnderecoRepository enderecoRepository) :
            base(uow, bus, notifications)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void Handle(RegistrarEnderecoCommand message)
        {
            var endereco = Endereco.EnderecoFactory.EnderecoCompleto(message.Id, message.Logradouro, message.Numero,
                message.Bairro, message.CidadeId, message.Cep);

            if (!endereco.IsValid()) return;

            _enderecoRepository.Adicionar(endereco);

            if (Commit())
            {
            }
        }

        public void Handle(AtualizarEnderecoCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}