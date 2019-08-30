using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.EmpresaUsuarios.Repository;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.EmpresaUsuarios.Command
{
    public class EmpresaUsuariosCommandHandler : CommandHandler, IHandler<RegistrarEmpresaUsuariosCommand>
    {
        private readonly IEmpresaUsuarioRepository _empresaUsuarioRepository;

        public EmpresaUsuariosCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            IEmpresaUsuarioRepository empresaUsuarioRepository) : base(uow, bus, notifications)
        {
            _empresaUsuarioRepository = empresaUsuarioRepository;
        }

        public void Handle(RegistrarEmpresaUsuariosCommand message)
        {
            var empresaUsuario =
                EmpresaUsuarios.EmpresaUsuariosFactory.EmpresaUsuariosCompleto(message.Id, message.UsuarioId,
                    message.EmpresaId);

            _empresaUsuarioRepository.Adicionar(empresaUsuario);

            if (Commit()){}
        }
    }
}