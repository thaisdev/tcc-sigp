using System;
using System.Linq;
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
        private readonly IBus _bus;

        public EnderecoCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IEnderecoRepository enderecoRepository) :
            base(uow, bus, notifications)
        {
            _bus = bus;
            _enderecoRepository = enderecoRepository;
        }

        public void Handle(RegistrarEnderecoCommand message)
        {
            var endereco = Endereco.EnderecoFactory.EnderecoCompleto(message.Id, message.Logradouro, message.Numero,
                message.Bairro, message.CidadeId, message.Cep);

            if (!ModelValidate(endereco)) return;

            if (EnderecoExistente(endereco.Logradouro, endereco.Numero, endereco.CidadeId)) return;

            _enderecoRepository.Adicionar(endereco);

            if (Commit())
            {
            }
        }

        public void Handle(AtualizarEnderecoCommand message)
        {
            var endereco = Endereco.EnderecoFactory.EnderecoCompleto(message.Id, message.Logradouro, message.Numero,
                message.Bairro, message.CidadeId, message.Cep);

            if (!ModelValidate(endereco)) return;

            _enderecoRepository.Atualizar(endereco);

            if (Commit())
            {
            }
        }

        private bool ModelValidate(Endereco endereco)
        {
            if (endereco.IsValid()) return true;

            NotificarValidacoesErro(endereco.ValidationResult);
            return false;
        }

        private bool EnderecoExistente(string logradouro, string numero, int cidadeId)
        {
            var endereco = _enderecoRepository.ObterTodos().FirstOrDefault(x =>
                x.Logradouro == logradouro && x.Numero == numero && x.CidadeId == cidadeId);

            return endereco != null;
        }
    }
}