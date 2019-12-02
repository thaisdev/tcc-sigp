using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.EnderecoEstoque.Repository;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.EnderecoEstoque.Commands
{
    public class EnderecoEstoqueCommandHandler : CommandHandler, IHandler<AtualizarEnderecoEstoqueCommand>,
        IHandler<ExcluirEnderecoEstoqueCommand>, IHandler<RegistrarEnderecoEstoqueCommand>
    {
        private readonly IEnderecoEstoqueRepository _enderecoEstoqueRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public EnderecoEstoqueCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications,
            IEnderecoEstoqueRepository enderecoEstoqueRepository) : base(uow, bus, notifications)
        {
            _enderecoEstoqueRepository = enderecoEstoqueRepository;
            _bus = bus;
        }   

        public void Handle(AtualizarEnderecoEstoqueCommand message)
        {
            var enderecoEstoque = EnderecoEstoque.EnderecoEstoqueFactory.EnderecoEstoqueCompleto(message.Id, message.DescricaoEndereco,
                message.Rua, message.Coluna);

            _enderecoEstoqueRepository.Adicionar(enderecoEstoque);
        }

        public void Handle(ExcluirEnderecoEstoqueCommand message)
        {
            _enderecoEstoqueRepository.Remover(message.Id);

            if (Commit())
            {
            }
        }

        public void Handle(RegistrarEnderecoEstoqueCommand message)
        {
            var enderecoEstoque = EnderecoEstoque.EnderecoEstoqueFactory.EnderecoEstoqueCompleto(message.Id, message.DescricaoEndereco,
                message.Rua, message.Coluna);

            _enderecoEstoqueRepository.Adicionar(enderecoEstoque);
        }
    }
}
