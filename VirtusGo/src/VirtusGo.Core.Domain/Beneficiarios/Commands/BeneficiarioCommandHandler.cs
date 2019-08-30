using System.Linq;
using VirtusGo.Core.Domain.Beneficiarios.Events;
using VirtusGo.Core.Domain.Beneficiarios.Repository;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Validations.Documento;

namespace VirtusGo.Core.Domain.Beneficiarios.Commands
{
    public class BeneficiarioCommandHandler : CommandHandler, IHandler<RegistrarBeneficiarioCommand>,
        IHandler<AtualizarBeneficiarioCommand>, IHandler<ExcluirBeneficiarioCommand>, IHandler<DesativarBeneficiarioCommand>, IHandler<ReativarBeneficiarioCommand>
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public BeneficiarioCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IBeneficiarioRepository beneficiarioRepository) : base(uow, bus, notifications)
        {
            _beneficiarioRepository = beneficiarioRepository;
            _bus = bus;
        }

        public void Handle(RegistrarBeneficiarioCommand message)
        {
            var beneficiario = Beneficiario.BeneficiarioFactory.BeneficiarioCompleto(message.Id, message.Nome, message.TipPessoa,
                message.NumeroDocumento, message.Ddd, message.Telefone, message.Email, message.Cep, message.Bairro,
                message.Endereco, message.Uf, message.Cidade, message.Excluido, message.UsuarioCriacaoId,
                message.UsuarioAlteracaoId, message.DataCadastro, message.DataAlteracao);

            var DocumentoValidation = beneficiario.TipPessoa == TipoPessoaEnum.Pf ? CPFValidation.Validar(beneficiario.NumeroDocumento) : CNPJValidation.Validar(beneficiario.NumeroDocumento);

            if (!DocumentoValidation == true)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Documento informado está inválido!"));
                return;
            }

            if (!EmailValidation.Validate(beneficiario.Email))
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Email informado está inválido!"));
                return;
            }

            if (!BeneficiarioValido(beneficiario)) return;

            var beneficiarioExistente = _beneficiarioRepository.Buscar(x =>
                x.NumeroDocumento == beneficiario.NumeroDocumento || x.Email == beneficiario.Email);

            if (beneficiarioExistente.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF ou Email já cadastrado!"));
                return;
            }

            _beneficiarioRepository.Adicionar(beneficiario);

            if (Commit())
            {
                _bus.RaiseEvent(new BeneficiarioRegistradoEvent(beneficiario.Id, beneficiario.Nome,
                    beneficiario.TipPessoa, beneficiario.NumeroDocumento,
                    beneficiario.Ddd, beneficiario.Telefone,
                    beneficiario.Email, beneficiario.Cep,
                    beneficiario.Bairro, beneficiario.Endereco,
                    beneficiario.Uf, beneficiario.Cidade,
                    beneficiario.Excluido, beneficiario.UsuarioCriacaoId,
                    beneficiario.UsuarioAlteracaoId, beneficiario.DataCadastro,
                    beneficiario.DataAlteracao));
            }
        }

        public void Handle(AtualizarBeneficiarioCommand message)
        {
            var beneficiario = Beneficiario.BeneficiarioFactory.BeneficiarioCompleto(message.Id, message.Nome, message.TipPessoa,
                message.NumeroDocumento, message.Ddd, message.Telefone, message.Email, message.Cep, message.Bairro,
                message.Endereco, message.Uf, message.Cidade, message.Excluido, message.UsuarioCriacaoId,
                message.UsuarioAlteracaoId, message.DataCadastro, message.DataAlteracao);

            var DocumentoValidation = beneficiario.TipPessoa == TipoPessoaEnum.Pf ? CPFValidation.Validar(beneficiario.NumeroDocumento) : CNPJValidation.Validar(beneficiario.NumeroDocumento);

            if (!DocumentoValidation == true)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Documento informado está inválido!"));
                return;
            }

            if (!EmailValidation.Validate(beneficiario.Email))
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Email informado está inválido!"));
                return;
            }

            if (!BeneficiarioExistente(message.Id, message.MessageType)) return;

            if (!BeneficiarioValido(beneficiario)) return;
            _beneficiarioRepository.Atualizar(beneficiario);

            if (Commit())
            {
                _bus.RaiseEvent(new BeneficiarioAtualizadoEvent(beneficiario.Id, beneficiario.Nome,
                    beneficiario.TipPessoa, beneficiario.NumeroDocumento,
                    beneficiario.Ddd, beneficiario.Telefone,
                    beneficiario.Email, beneficiario.Cep,
                    beneficiario.Bairro, beneficiario.Endereco,
                    beneficiario.Uf, beneficiario.Cidade,
                    beneficiario.Excluido, beneficiario.UsuarioCriacaoId,
                    beneficiario.UsuarioAlteracaoId, beneficiario.DataCadastro,
                    beneficiario.DataAlteracao));
            }
        }

        public void Handle(ExcluirBeneficiarioCommand message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(DesativarBeneficiarioCommand message)
        {
            var beneficiario = Beneficiario.BeneficiarioFactory.BeneficiarioCompleto(message.Id, message.Nome, message.TipPessoa,
                message.NumeroDocumento, message.Ddd, message.Telefone, message.Email, message.Cep, message.Bairro,
                message.Endereco, message.Uf, message.Cidade, message.Excluido, message.UsuarioCriacaoId,
                message.UsuarioAlteracaoId, message.DataCadastro, message.DataAlteracao);

            if (!BeneficiarioExistente(message.Id, message.MessageType)) return;

            //if (!BeneficiarioValido(beneficiario)) return;

            _beneficiarioRepository.Atualizar(beneficiario);

            if (Commit())
            {
                _bus.RaiseEvent(new BeneficiarioDesativadoEvent(beneficiario.Id, beneficiario.Nome, beneficiario.TipPessoa,
                    beneficiario.NumeroDocumento, beneficiario.Ddd, beneficiario.Telefone, beneficiario.Email, beneficiario.Cep, beneficiario.Bairro,
                    beneficiario.Endereco, beneficiario.Uf, beneficiario.Cidade, beneficiario.Excluido, beneficiario.UsuarioCriacaoId,
                    beneficiario.UsuarioAlteracaoId, beneficiario.DataCadastro, beneficiario.DataAlteracao));
            }
        }

        public void Handle(ReativarBeneficiarioCommand message)
        {
            var beneficiario = Beneficiario.BeneficiarioFactory.BeneficiarioCompleto(message.Id, message.Nome, message.TipPessoa,
                message.NumeroDocumento, message.Ddd, message.Telefone, message.Email, message.Cep, message.Bairro,
                message.Endereco, message.Uf, message.Cidade, message.Excluido, message.UsuarioCriacaoId,
                message.UsuarioAlteracaoId, message.DataCadastro, message.DataAlteracao);

            if (!BeneficiarioExistente(message.Id, message.MessageType)) return;

            //if (!BeneficiarioValido(beneficiario)) return;

            _beneficiarioRepository.Atualizar(beneficiario);

            if (Commit())
            {
                _bus.RaiseEvent(new BeneficiarioReativadoEvent(beneficiario.Id, beneficiario.Nome, beneficiario.TipPessoa,
                    beneficiario.NumeroDocumento, beneficiario.Ddd, beneficiario.Telefone, beneficiario.Email, beneficiario.Cep, beneficiario.Bairro,
                    beneficiario.Endereco, beneficiario.Uf, beneficiario.Cidade, beneficiario.Excluido, beneficiario.UsuarioCriacaoId,
                    beneficiario.UsuarioAlteracaoId, beneficiario.DataCadastro, beneficiario.DataAlteracao));
            }
        }

        private bool BeneficiarioValido(Beneficiario beneficiario)
        {
            if (beneficiario.IsValid()) return true;

            NotificarValidacoesErro(beneficiario.ValidationResult);
            return false;
        }

        private bool BeneficiarioExistente(int id, string messageType)
        {
            var beneficiario = _beneficiarioRepository.ObterPorId(id);

            if (beneficiario != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Beneficiario não encontrado."));
            return false;
        }
    }
}