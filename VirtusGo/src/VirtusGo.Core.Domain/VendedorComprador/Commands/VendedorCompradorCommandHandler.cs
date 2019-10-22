using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.VendedorComprador.Repository;

namespace VirtusGo.Core.Domain.VendedorComprador.Commands
{
    public class VendedorCompradorCommandHandler : CommandHandler, IHandler<AtualizarVendedorCompradorCommand>,
        IHandler<ExcluirVendedorCompradorCommand>, IHandler<RegistrarVendedorCompradorCommand>
    {
        private readonly IVendedorCompradorRepository _vendedorCompradorRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public VendedorCompradorCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IVendedorCompradorRepository vendedorCompradorRepository) : base(uow, bus, notifications)
        {
            _vendedorCompradorRepository = vendedorCompradorRepository;
            _bus = bus;
        }

        public void Handle(AtualizarVendedorCompradorCommand message)
        {
            var vendedorComprador = VendedorComprador.VendedorCompradorFactory.VendedorCompradorCompleto(message.Id, message.Nome,
                message.Vendedor, message.Comprador, message.Comissao);

            _vendedorCompradorRepository.Adicionar(vendedorComprador);
        }

        public void Handle(ExcluirVendedorCompradorCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(RegistrarVendedorCompradorCommand message)
        {
            var vendedorComprador = VendedorComprador.VendedorCompradorFactory.VendedorCompradorCompleto(message.Id, message.Nome,
                message.Vendedor, message.Comprador, message.Comissao);

            _vendedorCompradorRepository.Adicionar(vendedorComprador);
        }
    }
}
