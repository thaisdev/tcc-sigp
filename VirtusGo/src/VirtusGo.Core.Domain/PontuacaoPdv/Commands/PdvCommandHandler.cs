using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.PontuacaoPdv.Events;
using VirtusGo.Core.Domain.PontuacaoPdv.Repository;
using VirtusGo.Core.Domain.Validations.Documento;

namespace VirtusGo.Core.Domain.PontuacaoPdv.Commands
{
    public class PdvCommandHandler : CommandHandler, IHandler<AprovarPdvCommand>, IHandler<ExcluirPdvCommand>
    {

        private readonly IBus _bus;
        private readonly IPontuacaoPDVRepository _pontuacaoPdvRepository;

        public PdvCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IPontuacaoPDVRepository pontuacaoPdvRepository) : base(uow, bus, notifications)
        {
            _bus = bus;
            _pontuacaoPdvRepository = pontuacaoPdvRepository;
        }

        public void Handle(ExcluirPdvCommand message)
        {
            var pdv = PontuacaoPDV.PontuacaoPdvFactory.PontuacaoPdvCompleto(message.Id, message.ValorLancamento,
                message.DataCompra, message.Cpf, message.Operador, message.Email, message.FlagExcluido,
                message.FlagInterface, message.DataInterface, message.UsuarioIdInterface, message.FlagErroInterface,
                message.MensagemErroInterface, message.UnidadeId, message.EmpresaId);

            _pontuacaoPdvRepository.Atualizar(pdv);
            
            if (Commit())
            {
                _bus.RaiseEvent(new PdvExcluidoEvent(pdv.Id));   
            }
        }

        public void Handle(AprovarPdvCommand message)
        {
            var pdv = PontuacaoPDV.PontuacaoPdvFactory.PontuacaoPdvCompleto(message.Id, message.ValorLancamento,
                message.DataCompra, message.Cpf, message.Operador, message.Email, message.FlagExcluido,
                message.FlagInterface, message.DataInterface, message.UsuarioIdInterface, message.FlagErroInterface,
                message.MensagemErroInterface, message.UnidadeId, message.EmpresaId);
            
            if (pdv.Cpf == "")
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Não é possivel validar um CPF nulo!"));
                return;
            }

            if (CPFValidation.Validar(pdv.Cpf) != true)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF está incorreto!"));
                return;
            }

            _pontuacaoPdvRepository.Atualizar(pdv);
            
            if (Commit())
            {
                _bus.RaiseEvent(new PdvAprovadoEvent(pdv.Id));   
            }
        }
    }
}