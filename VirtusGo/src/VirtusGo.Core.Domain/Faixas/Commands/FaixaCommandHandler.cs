using System.Linq.Expressions;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Command;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Faixas.Events;
using VirtusGo.Core.Domain.Faixas.Repository;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Faixas.Commands
{
    public class FaixaCommandHandler : CommandHandler, IHandler<RegistrarFaixaCommand>, IHandler<AtualizarFaixaCommand>,
        IHandler<ExcluirFaixaCommand>
    {
        private readonly IBus _bus;
        private readonly IFaixaRepository _faixaRepository;

        public FaixaCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IFaixaRepository faixaRepository) : base(uow,
            bus, notifications)
        {
            _bus = bus;
            _faixaRepository = faixaRepository;
        }

        public void Handle(RegistrarFaixaCommand message)
        {
            var faixa = Faixa.FaixaFactory.FaixaCompleta(message.Id, message.ValorDe, message.ValorAte,
                message.ValorPorcentagem, message.FlagExcluido, message.DataCriacao, message.DataAlteracao,
                message.EmpresaId, message.UnidadeId, message.UsuarioIdCriacao, message.UsuarioIdAltera);

            if (!faixa.IsValid())
            {
                foreach (var item in faixa.ValidationResult.Errors)
                {
                    _bus.RaiseEvent(new DomainNotification(message.MessageType, item.ErrorMessage));
                }

                return;
            }

            _faixaRepository.Adicionar(faixa);

            if (Commit())
            {
                _bus.RaiseEvent(new FaixaRegistradaEvent(message.ValorDe, message.ValorAte,
                    message.ValorPorcentagem, message.FlagExcluido, message.DataCriacao, message.DataAlteracao,
                    message.EmpresaId, message.UnidadeId, message.UsuarioIdCriacao, message.UsuarioIdAltera));
            }
        }

        public void Handle(AtualizarFaixaCommand message)
        {
            var faixa = Faixa.FaixaFactory.FaixaCompleta(message.Id, message.ValorDe, message.ValorAte,
                message.ValorPorcentagem, message.FlagExcluido, message.DataCriacao, message.DataAlteracao,
                message.EmpresaId, message.UnidadeId, message.UsuarioIdCriacao, message.UsuarioIdAltera);

            if (!faixa.IsValid())
            {
                foreach (var item in faixa.ValidationResult.Errors)
                {
                    _bus.RaiseEvent(new DomainNotification(message.MessageType, item.ErrorMessage));
                }

                return;
            }

            var faixaExistente = _faixaRepository.ObterPorFaixaId(faixa.Id);
            if (faixaExistente == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Faixa não encontrada"));
                return;
            }

            _faixaRepository.Atualizar(faixa);

            if (Commit())
            {
                _bus.RaiseEvent(new FaixaAtualizadaEvent(faixa.ValorDe, faixa.ValorAte,
                    faixa.ValorPorcentagem, faixa.FlagExcluido, faixa.DataCriacao, faixa.DataAlteracao,
                    faixa.EmpresaId, faixa.UnidadeId, faixa.UsuarioIdCriacao, faixa.UsuarioIdAltera));
            }
        }

        public void Handle(ExcluirFaixaCommand message)
        {
            var faixa = Faixa.FaixaFactory.FaixaCompleta(message.Id, message.ValorDe, message.ValorAte,
                message.ValorPorcentagem, message.FlagExcluido, message.DataCriacao, message.DataAlteracao,
                message.EmpresaId, message.UnidadeId, message.UsuarioIdCriacao, message.UsuarioIdAltera);

            if (!faixa.IsValid())
            {
                foreach (var item in faixa.ValidationResult.Errors)
                {
                    _bus.RaiseEvent(new DomainNotification(message.MessageType, item.ErrorMessage));
                }

                return;
            }
            
            _faixaRepository.Atualizar(faixa);

            if (Commit())
            {
                _bus.RaiseEvent(new FaixaExcluidaEvent(faixa.Id));
            }
        }
    }
}