using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Parametro.Event;
using VirtusGo.Core.Domain.Parametro.Repository;

namespace VirtusGo.Core.Domain.Parametro.Command
{
    public class ParametroCommandHandler : CommandHandler, IHandler<RegistrarParametroCommand>, IHandler<AtualizarParametroCommand>,
        IHandler<DesativarParametroCommand>
    {
        private readonly IParametroRepository _parametroRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public ParametroCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IParametroRepository parametroRepository, IUser user) : base(uow, bus, notifications)
        {
            _parametroRepository = parametroRepository;
            _bus = bus;
            _user = user;
        }
        
        public void Handle(RegistrarParametroCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(AtualizarParametroCommand message)
        {
            var parametro = Parametro.ParametroFactory.ParametroCompeleto(message.Id, message.DiasParaExpiracaoPontos,
                message.ValorComissaoGeral, message.ValorPorcentagemGeralPontosFaixa, message.FlagExcluido, message.DataCriacao, message.DataAlteracao,
                message.UsuarioIdCriacao, message.UsuarioIdAlteracao);
            
            if(!ParametroExistente(parametro.Id, message.MessageType)) return;
            
            _parametroRepository.Atualizar(parametro);

            if (Commit())
            {
                _bus.RaiseEvent(new ParametroAtualizadoEvent(parametro.Id, parametro.DiasParaExpiracaoPontos,
                    parametro.ValorComissaoGeral, parametro.ValorPorcentagemGeralPontosFaixa, parametro.FlagExcluido, parametro.DataCriacao, parametro.DataAlteracao,
                    parametro.UsuarioIdCriacao, parametro.UsuarioIdAlteracao));
            }
        }

        public void Handle(DesativarParametroCommand message)
        {
            throw new System.NotImplementedException();
        }
        
        private bool ParametroExistente(int id, string messageType)
        {
            var unidade = _parametroRepository.ObterPorId(id);

            if (unidade != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Parametro não encontrado."));
            return false;
        }
    }
}