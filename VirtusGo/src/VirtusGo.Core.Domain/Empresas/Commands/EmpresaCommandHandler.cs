using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Empresas.Repository;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Empresas.Commands
{
    public class EmpresaCommandHandler : CommandHandler, IHandler<RegistrarEmpresaCommand>, IHandler<AtualizarEmpresaCommand>,
        IHandler<ExcluirEmpresaCommand>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public EmpresaCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IEmpresaRepository empresaRepository) : base(uow, bus, notifications)
        {
            _empresaRepository = empresaRepository;
            _bus = bus;
        }   

        public void Handle(RegistrarEmpresaCommand message)
        {
            var empresa = Empresa.Empresa.EmpresaFactory.EmpresaCompleto(
                message.Id, message.Razao, message.CNPJ, message.Inscri, message.EnderecoId);
           
            _empresaRepository.Adicionar(empresa);
        }

        public void Handle(AtualizarEmpresaCommand message)
        {
            var empresa = Empresa.Empresa.EmpresaFactory.EmpresaCompleto(
                message.Id, message.Razao, message.CNPJ, message.Inscri, message.EnderecoId);
            
            _empresaRepository.Adicionar(empresa);
        }

        public void Handle(ExcluirEmpresaCommand message)
        {
            throw new NotImplementedException();
        }
                
    }
}
