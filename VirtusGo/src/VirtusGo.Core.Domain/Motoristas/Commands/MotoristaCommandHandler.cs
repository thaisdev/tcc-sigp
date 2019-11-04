using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Motoristas.Repository;

namespace VirtusGo.Core.Domain.Motoristas.Commands
{
    public class MotoristaCommandHandler : CommandHandler, IHandler<AtualizarMotoristaCommand>,
        IHandler<ExcluirMotoristaCommand>, IHandler<RegistrarMotoristaCommand>
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public MotoristaCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IMotoristaRepository motoristaRepository) :
            base(uow, bus, notifications)
        {
            _motoristaRepository = motoristaRepository;
            _bus = bus;
        }

        public void Handle(AtualizarMotoristaCommand message)
        {
            var motorista = Motorista.MotoristaFactory.MotoristaCompleto(
                message.Id, message.Nome, message.CPF, message.CategoriaCNH, message.NumeroCNH, message.Telefone,
                message.DataNascimento,
                message.DataVencimentoCNH, message.EnderecoId);

            if (!motorista.IsValid()) return;

            _motoristaRepository.Atualizar(motorista);

            if (Commit())
            {
            }
        }

        public void Handle(ExcluirMotoristaCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(RegistrarMotoristaCommand message)
        {
            var motorista = Motoristas.Motorista.MotoristaFactory.MotoristaCompleto(
                message.Id, message.Nome, message.CPF, message.CategoriaCNH, message.NumeroCNH, message.Telefone,
                message.DataNascimento,
                message.DataVencimentoCNH, message.EnderecoId);

            if (!ModelValidate(motorista)) return;

            _motoristaRepository.Adicionar(motorista);

            if (Commit())
            {
            }
        }

        private bool ModelValidate(Motorista motorista)
        {
            if (motorista.IsValid()) return true;

            NotificarValidacoesErro(motorista.ValidationResult);
            return false;
        }
    }
}