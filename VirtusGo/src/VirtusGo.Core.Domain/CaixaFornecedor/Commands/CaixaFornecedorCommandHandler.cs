using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.CaixaFornecedor.Repository;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.CaixaFornecedor.Commands
{
    public class CaixaFornecedorCommandHandler : CommandHandler, IHandler<AtualizarCaixaFornecedorCommand>, IHandler<ExcluirCaixaFornecedorCommand>,
        IHandler<RegistrarCaixaFornecedorCommand>
    {
        private readonly ICaixaFornecedorRepository _caixaFornecedorRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public CaixaFornecedorCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications,
            ICaixaFornecedorRepository caixaFornecedorRepository) : base(uow, bus, notifications)
        {
            _caixaFornecedorRepository = caixaFornecedorRepository;
            _bus = bus;
        }

        public void Handle(AtualizarCaixaFornecedorCommand message)
        {
            var caixaFornecedor = CaixaFornecedor.CaixaFornecedorFactory.CaixaFornecedorCompleto(message.Id, message.ParceiroId, message.Data);

            _caixaFornecedorRepository.Adicionar(caixaFornecedor);
        }

        public void Handle(ExcluirCaixaFornecedorCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(RegistrarCaixaFornecedorCommand message)
        {
            var caixaFornecedor = CaixaFornecedor.CaixaFornecedorFactory.CaixaFornecedorCompleto(message.Id, message.ParceiroId, message.Data);

            _caixaFornecedorRepository.Adicionar(caixaFornecedor);
        }
    }
}
