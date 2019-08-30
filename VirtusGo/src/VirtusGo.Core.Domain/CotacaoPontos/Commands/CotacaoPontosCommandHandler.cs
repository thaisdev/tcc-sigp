using System;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.CotacaoPontos.Events;
using VirtusGo.Core.Domain.CotacaoPontos.Repository;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.CotacaoPontos.Commands
{
    public class CotacaoPontosCommandHandler : CommandHandler, IHandler<RegistrarCotacaoPontosCommand>,
        IHandler<AtualizarCotacaoPontosCommand>, IHandler<ExcluirCotacaoPontosCommand>, IHandler<DesativarCotacaoCommand>
    {
        private readonly ICotacaoPontosRepository _cotacaoPontosRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public CotacaoPontosCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            ICotacaoPontosRepository cotacaoPontosRepository) : base(uow, bus, notifications)
        {
            _cotacaoPontosRepository = cotacaoPontosRepository;
            _bus = bus;
        }

        public void Handle(RegistrarCotacaoPontosCommand message)
        {
            var cotacao = CotacaoPontos.CotacaoFactory.CotacaoPontosCompleto(message.Id, message.Valor,
                message.DataVigencia, message.FlagExcluido, message.DataCriacao, message.DataAlteracao,
                message.UsuarioIdCriacao, message.UsuarioIdAltera);

            var dataValidation = DateTime.Compare(cotacao.DataVigencia, DateTime.Now);
            if (dataValidation != 1)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType,
                    "Data de vigência precisa ser igual ou posterior a data de hoje"));
                return;
            }

            _cotacaoPontosRepository.Adicionar(cotacao);
            if (Commit())
            {
                _bus.RaiseEvent(new CotacaoPontosRegistradoEvent(cotacao.Id, cotacao.Valor,
                    cotacao.DataVigencia, cotacao.FlagExcluido, cotacao.DataCriacao, cotacao.DataAlteracao,
                    cotacao.UsuarioIdCriacao, cotacao.UsuarioIdAltera));
            }
        }

        public void Handle(AtualizarCotacaoPontosCommand message)
        {
            var cotacao = CotacaoPontos.CotacaoFactory.CotacaoPontosCompleto(message.Id, message.Valor,
                message.DataVigencia, message.FlagExcluido, message.DataCriacao, message.DataAlteracao,
                message.UsuarioIdCriacao, message.UsuarioIdAltera);
            
            if (!CotacaoExistente(message.Id, message.MessageType)) return;

            _cotacaoPontosRepository.Atualizar(cotacao);

            if (Commit())
            {
                _bus.RaiseEvent(new CotacaoPontosAtualizadaEvent(cotacao.Id, cotacao.Valor,
                    cotacao.DataVigencia, cotacao.FlagExcluido, cotacao.DataCriacao, cotacao.DataAlteracao,
                    cotacao.UsuarioIdCriacao, cotacao.UsuarioIdAltera));
            }
        }

        public void Handle(ExcluirCotacaoPontosCommand message)
        {
            throw new NotImplementedException();
        }

        private bool CotacaoExistente(int id, string messageType)
        {
            var cotacaoPontos = _cotacaoPontosRepository.ObterPorId(id);

            if (cotacaoPontos != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Cotação não encontrada."));
            return false;
        }

        public void Handle(DesativarCotacaoCommand message)
        {
            var cotacao = CotacaoPontos.CotacaoFactory.CotacaoPontosCompleto(message.Id, message.Valor,
                message.DataVigencia, message.FlagExcluido, message.DataCriacao, message.DataAlteracao,
                message.UsuarioIdCriacao, message.UsuarioIdAltera);

            if (!CotacaoExistente(message.Id, message.MessageType)) return;

            _cotacaoPontosRepository.Atualizar(cotacao);

            if (Commit())
            {
                _bus.RaiseEvent(new CotacaoPontosRegistradoEvent(cotacao.Id, cotacao.Valor,
                    cotacao.DataVigencia, cotacao.FlagExcluido, cotacao.DataCriacao, cotacao.DataAlteracao,
                    cotacao.UsuarioIdCriacao, cotacao.UsuarioIdAltera));
            }
        }
    }
}