using System.Linq;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Empresa.Repository;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Unidades.Events;
using VirtusGo.Core.Domain.Unidades.Repository;
using VirtusGo.Core.Domain.Validations.Documento;

namespace VirtusGo.Core.Domain.Unidades.Commands
{
    public class UnidadeCommandHandler : CommandHandler, IHandler<RegistrarUnidadeCommand>,
        IHandler<AtualizarUnidadeCommand>, IHandler<ExcluirUnidadeCommand>, IHandler<DesativarUnidadeCommand>,
        IHandler<ReativarUnidadeCommand>
    {
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public UnidadeCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IUnidadeRepository unidadeRepository,
            IEmpresaRepository empresaRepository, IUser user) : base(uow, bus, notifications)
        {
            _unidadeRepository = unidadeRepository;
            _empresaRepository = empresaRepository;
            _bus = bus;
            _user = user;
        }

        public void Handle(RegistrarUnidadeCommand message)
        {
            var unidade = Unidade.UnidadeFactory.UnidadeCompleta(message.Id, message.RazaoSocial, message.Fantasia,
                message.Documento, message.Email, message.Ddd, message.Telefone, message.Cep, message.Bairro,
                message.Endereco, message.Latitude, message.Longitude, message.Ramo, message.Uf, message.Cidade,
                message.FlagBloqueado, message.FlagExcluido,
                message.UsuarioIdCriador, message.UsuarioIdAltera, message.EmpresaId, message.DataCriacao,
                message.DataAlteracao, message.NumeroDiasParaExpiracaoPontos, message.ComissaoGeral,
                message.ValorPorcentagemGeralPontos);

            var unidadeCount = _unidadeRepository.ObterTodosAtivosPorEmpresa(unidade.EmpresaId).Count();
            var qtdMaxUnidade = _empresaRepository.ObterPorEmpresaId(unidade.EmpresaId).QuantidadeFilial;

            if (unidadeCount >= qtdMaxUnidade)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType,
                    "Quantidade máxima de unidades atingida para esta empresa"));
                return;
            }

            var documentoValidation = CNPJValidation.Validar(unidade.Documento);

            if (!documentoValidation)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CNPJ informado está inválido!"));
                return;
            }

            if (!EmailValidation.Validate(unidade.Email))
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Email informado está inválido!"));
                return;
            }

            if (!UnidadeValido(unidade)) return;

            var unidadeExistente =
                _unidadeRepository.Buscar(x => x.Email == unidade.Email || x.Fantasia == unidade.Fantasia);

            if (unidadeExistente.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Nome Fantasia ou Email já cadastrados"));
                return;
            }

            _unidadeRepository.Adicionar(unidade);
            if (Commit())
            {
                _bus.RaiseEvent(new UnidadeRegistradaEvent(unidade.Id, unidade.RazaoSocial, unidade.Fantasia,
                    unidade.Documento, unidade.Email, unidade.Ddd, unidade.Telefone, unidade.Cep, unidade.Bairro,
                    unidade.Endereco, unidade.Uf, unidade.Cidade, unidade.FlagBloqueado, unidade.FlagExcluido,
                    unidade.UsuarioIdCriador, unidade.UsuarioIdAltera, unidade.EmpresaId, unidade.DataCriacao,
                    unidade.DataAlteracao, unidade.NumeroDiasParaExpiracaoPontos, unidade.ComissaoGeral,
                    unidade.ValorPorcentagemGeralPontos));
            }
        }

        public void Handle(AtualizarUnidadeCommand message)
        {
            var unidade = Unidade.UnidadeFactory.UnidadeCompleta(message.Id, message.RazaoSocial, message.Fantasia,
                message.Documento, message.Email, message.Ddd, message.Telefone, message.Cep, message.Bairro,
                message.Endereco, message.Latitude, message.Longitude, message.Ramo, message.Uf, message.Cidade,
                message.FlagBloqueado, message.FlagExcluido,
                message.UsuarioIdCriador, message.UsuarioIdAltera, message.EmpresaId, message.DataCriacao,
                message.DataAlteracao, message.NumeroDiasParaExpiracaoPontos, message.ComissaoGeral,
                message.ValorPorcentagemGeralPontos);

            var documentoValidation = CNPJValidation.Validar(unidade.Documento);

            if (!documentoValidation)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CNPJ informado está inválido!"));
                return;
            }

            if (!EmailValidation.Validate(unidade.Email))
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Email informado está inválido!"));
                return;
            }

            if (!UnidadeExistente(message.Id, message.MessageType)) return;

            if (!UnidadeValido(unidade)) return;

            _unidadeRepository.Atualizar(unidade);

            if (Commit())
            {
                _bus.RaiseEvent(new UnidadeAtualizadaEvent(unidade.Id, unidade.RazaoSocial, unidade.Fantasia,
                    unidade.Documento, unidade.Email, unidade.Ddd, unidade.Telefone, unidade.Cep, unidade.Bairro,
                    unidade.Endereco, unidade.Uf, unidade.Cidade, unidade.FlagBloqueado, unidade.FlagExcluido,
                    unidade.UsuarioIdCriador, unidade.UsuarioIdAltera, unidade.EmpresaId, unidade.DataCriacao,
                    unidade.DataAlteracao, unidade.NumeroDiasParaExpiracaoPontos, unidade.ComissaoGeral,
                    unidade.ValorPorcentagemGeralPontos));
            }
        }

        public void Handle(ExcluirUnidadeCommand message)
        {
            throw new System.NotImplementedException();
        }

        private bool UnidadeValido(Unidade unidade)
        {
            if (unidade.IsValid()) return true;

            NotificarValidacoesErro(unidade.ValidationResult);
            return false;
        }

        private bool UnidadeExistente(int id, string messageType)
        {
            var unidade = _unidadeRepository.ObterPorId(id);

            if (unidade != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Unidade não encontrada."));
            return false;
        }

        public void Handle(DesativarUnidadeCommand message)
        {
            var unidade = Unidade.UnidadeFactory.UnidadeCompleta(message.Id, message.RazaoSocial, message.Fantasia,
                message.Documento, message.Email, message.Ddd, message.Telefone, message.Cep, message.Bairro,
                message.Endereco, message.Latitude, message.Longitude, message.Ramo, message.Uf, message.Cidade,
                message.FlagBloqueado, message.FlagExcluido,
                message.UsuarioIdCriador, message.UsuarioIdAltera, message.EmpresaId, message.DataCriacao,
                message.DataAlteracao, message.NumeroDiasParaExpiracaoPontos, message.ComissaoGeral,
                message.ValorPorcentagemGeralPontos);

            if (!UnidadeExistente(message.Id, message.MessageType)) return;

            if (unidade.FlagExcluido == FlagExcluidoEnum.nao && unidade.FlagBloqueado == FlagBloqueadoEnum.nao)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Unidade já está ativa!"));
                return;
            }

            _unidadeRepository.Atualizar(unidade);

            if (Commit())
            {
                _bus.RaiseEvent(new UnidadeDesativadaEvent(unidade.Id));
            }
        }

        public void Handle(ReativarUnidadeCommand message)
        {
            var unidade = Unidade.UnidadeFactory.UnidadeCompleta(message.Id, message.RazaoSocial, message.Fantasia,
                message.Documento, message.Email, message.Ddd, message.Telefone, message.Cep, message.Bairro,
                message.Endereco, message.Latitude, message.Longitude, message.Ramo, message.Uf, message.Cidade,
                message.FlagBloqueado, message.FlagExcluido,
                message.UsuarioIdCriador, message.UsuarioIdAltera, message.EmpresaId, message.DataCriacao,
                message.DataAlteracao, message.NumeroDiasParaExpiracaoPontos, message.ComissaoGeral,
                message.ValorPorcentagemGeralPontos);

            if (!UnidadeExistente(message.Id, message.MessageType))
            {
                return;
            }

//            if (!UnidadeValido(unidade)) return;

            _unidadeRepository.Atualizar(unidade);

            if (Commit())
            {
                _bus.RaiseEvent(new UnidadeReativadaEvent(unidade.Id));
            }
        }
    }
}