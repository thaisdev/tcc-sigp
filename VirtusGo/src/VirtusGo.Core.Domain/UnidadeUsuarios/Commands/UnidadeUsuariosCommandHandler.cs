using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.UnidadeUsuarios.Repository;

namespace VirtusGo.Core.Domain.UnidadeUsuarios.Commands
{
    public class UnidadeUsuariosCommandHandler : CommandHandler, IHandler<RegistrarUnidadeUsuariosCommand>
    {
        private readonly IUnidadeUsuarioRepository _unidadeUsuarioRepository;
        public UnidadeUsuariosCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IUnidadeUsuarioRepository unidadeUsuarioRepository) : base(uow, bus, notifications)
        {
            _unidadeUsuarioRepository = unidadeUsuarioRepository;
        }

        public void Handle(RegistrarUnidadeUsuariosCommand message)
        {
            var unidadeUsuarios =
                UnidadeUsuarios.UnidadeUsuariosFactory.UnidadeUsuariosCompleto(message.Id, message.UsuarioId,
                    message.UnidadeId);
            
            _unidadeUsuarioRepository.Adicionar(unidadeUsuarios);

            if (Commit()) ;
        }
    }
}
