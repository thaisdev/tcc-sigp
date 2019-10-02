using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Rastreabilidade.Repository;

namespace VirtusGo.Core.Domain.Rastreabilidade.Commands
{
    public class RastreabilidadeCommandHandler : CommandHandler,
        IHandler<AtualizarRastreabilidadeCommand>, IHandler<ExcluirRastreabilidadeCommand>, IHandler<RegistrarRastreabilidadeCommand>
    {

        private readonly IRastreabilidadeRepository _rastreabilidadeRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public RastreabilidadeCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications,
            IRastreabilidadeRepository rastreabilidadeRepository) : base(uow, bus, notifications)
        {
            _rastreabilidadeRepository = rastreabilidadeRepository;
            _bus = bus;
        }

        public void Handle(AtualizarRastreabilidadeCommand message)
        {
            var rastreabilidade = Rastreabilidade.RastreabilidadeFactory.RastreabilidadeCompleta(message.PedidoCompraId,
                message.PedidoVendaId, message.ProdutoId, message.Quantidade);

            _rastreabilidadeRepository.Adicionar(rastreabilidade);
        }

        public void Handle(ExcluirRastreabilidadeCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(RegistrarRastreabilidadeCommand message)
        {
            var rastreabilidade = Rastreabilidade.RastreabilidadeFactory.RastreabilidadeCompleta(message.PedidoCompraId,
                message.PedidoVendaId, message.ProdutoId, message.Quantidade);

            _rastreabilidadeRepository.Adicionar(rastreabilidade);
        }
    }
}
