using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Pontuacao.Events;
using VirtusGo.Core.Domain.Pontuacao.Repository;

namespace VirtusGo.Core.Domain.Pontuacao.Commands
{
    public class PontuacaoCommandHandler : CommandHandler, IHandler<RegistrarPontuacaoCommand>,
        IHandler<AtualizarPontuacaoCommand>, IHandler<ExcluirPontuacaoCommand>, IHandler<DesativarPontuacaoCommand>
    {
        private readonly IPontuacaoRepository _pontuacaoRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public PontuacaoCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IPontuacaoRepository pontuacaoRepository) :
            base(uow, bus, notifications)
        {
            _pontuacaoRepository = pontuacaoRepository;
            _bus = bus;
        }

        public void Handle(RegistrarPontuacaoCommand message)
        {
            var pontuacao = Pontuacao.PontuacaoFactory.PontuacaoCompleto(message.Id, message.BeneficiarioId,
                message.ValorLancamento, message.UsuarioIdCriacao, message.UsuarioIdAlteracao, message.DataCompra,
                message.DataLancamento, message.DataAlteracao, message.FlagExcluido, message.FlagInterface,
                message.DataInterface, message.UsuarioIdInterface, message.FlagErroInterface,
                message.DescricaoErroInterface, message.EmpresaId, message.UnidadeId);

            if (!PontuacaoValida(pontuacao)) return;

            _pontuacaoRepository.Adicionar(pontuacao);
            if (Commit())
            {
                _bus.RaiseEvent(new PontuacaoRegistradaEvent(pontuacao.BeneficiarioId, pontuacao.ValorLancamento,
                    pontuacao.UsuarioIdCriacao, pontuacao.UsuarioIdAlteracao,
                    pontuacao.DataCompra, pontuacao.DataLancamento, pontuacao.DataAlteracao, pontuacao.FlagExcluido,
                    pontuacao.FlagInterface, pontuacao.DataInterface,
                    pontuacao.UsuarioIdInterface, pontuacao.FlagErroInterface, pontuacao.DescricaoErroInterface,
                    pontuacao.EmpresaId, pontuacao.UnidadeId));
            }
        }

        public void Handle(AtualizarPontuacaoCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(DesativarPontuacaoCommand message)
        {
            var pontuacao = Pontuacao.PontuacaoFactory.PontuacaoCompleto(message.Id, message.BeneficiarioId,
                message.ValorLancamento, message.UsuarioIdCriacao, message.UsuarioIdAlteracao, message.DataCompra,
                message.DataLancamento, message.DataAlteracao, message.FlagExcluido, message.FlagInterface,
                message.DataInterface, message.UsuarioIdInterface, message.FlagErroInterface,
                message.DescricaoErroInterface, message.EmpresaId, message.UnidadeId);
            
            _pontuacaoRepository.Atualizar(pontuacao);

            if (Commit())
            {
                _bus.RaiseEvent(new PontuacaoRegistradaEvent(pontuacao.BeneficiarioId, pontuacao.ValorLancamento,
                    pontuacao.UsuarioIdCriacao, pontuacao.UsuarioIdAlteracao,
                    pontuacao.DataCompra, pontuacao.DataLancamento, pontuacao.DataAlteracao, pontuacao.FlagExcluido,
                    pontuacao.FlagInterface, pontuacao.DataInterface,
                    pontuacao.UsuarioIdInterface, pontuacao.FlagErroInterface, pontuacao.DescricaoErroInterface,
                    pontuacao.EmpresaId, pontuacao.UnidadeId));
            }
        }

        public void Handle(ExcluirPontuacaoCommand message)
        {
            throw new NotImplementedException();
        }

        //Validações
        private bool PontuacaoValida(Pontuacao pontuacao)
        {
            return true;
        }
    }
}