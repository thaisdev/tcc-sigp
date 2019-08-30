using System.Linq;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Empresa.Events;
using VirtusGo.Core.Domain.Empresa.Repository;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Validations.Documento;

namespace VirtusGo.Core.Domain.Empresa.Commands
{
    public class EmpresaCommandHandler : CommandHandler, IHandler<RegistrarEmpresaCommand>,
        IHandler<AtualizarEmpresaCommand>, IHandler<ExcluirEmpresaCommand>, IHandler<DesativarEmpresaCommand>,
        IHandler<ReativarEmpresaCommand>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public EmpresaCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications, IEmpresaRepository empresaRepository,
            IUser user) : base(uow, bus, notifications)
        {
            _empresaRepository = empresaRepository;
            _bus = bus;
            _user = user;
        }

        public void Handle(RegistrarEmpresaCommand message)
        {
            var empresa = Empresas.EmpresaFactory.EmpresaCompleta(message.Id, message.RazaoSocial, message.NomeFantasia,
                message.NumeroDocumento, message.Bloqueado, message.Excluido, message.Email, message.Email2,
                message.Email3, message.Cep, message.Bairro, message.Endereco, message.Latitude, message.Longitude,
                message.Ramo, message.ProfissionalLiberal, message.Plano, message.Uf, message.Cidade,
                message.Contato, message.Contato2, message.Ddd, message.Telefone, message.Ddd2, message.Telefone2,
                message.Ddd3, message.Telefone3, message.QuantidadeFilial, message.DiasParaExpiracaoPontos,
                message.ValorComissãoGeral, message.PorcentagemPadraoPontos, message.DataCriacao, message.DataAlteracao,
                message.UsuarioIdCriacao, message.UsuarioIdAlteracao);

            if (!EmpresaValida(empresa)) return;

            var documentoValidation = CNPJValidation.Validar(empresa.NumeroDocumento);

            if (!documentoValidation == true)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CNPJ informado está inválido!"));
                return;
            }

            if (!EmailValidation.Validate(empresa.Email) == true)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Email informado está inválido!"));
                return;
            }

            var empresaExistente = _empresaRepository.Buscar(x =>
                x.NumeroDocumento == empresa.NumeroDocumento || x.Email == empresa.Email);

            if (empresaExistente.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CNPJ ou Email já cadastrado!"));
                return;
            }

            _empresaRepository.Adicionar(empresa);

            if (Commit())
            {
                _bus.RaiseEvent(new EmpresaRegistradaEvent(empresa.RazaoSocial, empresa.NomeFantasia,
                    empresa.NumeroDocumento, empresa.Bloqueado, empresa.Excluido, empresa.Email, empresa.Email2,
                    empresa.Email3, empresa.Cep, empresa.Bairro, empresa.Endereco, empresa.Uf, empresa.Cidade,
                    empresa.Contato, empresa.Contato2, empresa.Ddd, empresa.Telefone, empresa.Ddd2, empresa.Telefone2,
                    empresa.Ddd3, empresa.Telefone3, empresa.QuantidadeFilial, empresa.DiasParaExpiracaoPontos,
                    empresa.ValorComissãoGeral, empresa.PorcentagemPadraoPontos, empresa.DataCriacao,
                    empresa.DataAlteracao, empresa.UsuarioIdCriacao, empresa.UsuarioIdAlteracao));
            }
        }

        public void Handle(AtualizarEmpresaCommand message)
        {
            var empresa = Empresas.EmpresaFactory.EmpresaCompleta(message.Id, message.RazaoSocial, message.NomeFantasia,
                message.NumeroDocumento, message.Bloqueado, message.Excluido, message.Email, message.Email2,
                message.Email3, message.Cep, message.Bairro, message.Endereco, message.Latitude, message.Longitude,
                message.Ramo, message.ProfissionalLiberal, message.Plano, message.Uf, message.Cidade,
                message.Contato, message.Contato2, message.Ddd, message.Telefone, message.Ddd2, message.Telefone2,
                message.Ddd3, message.Telefone3, message.QuantidadeFilial, message.DiasParaExpiracaoPontos,
                message.ValorComissãoGeral, message.PorcentagemPadraoPontos, message.DataCriacao, message.DataAlteracao,
                message.UsuarioIdCriacao, message.UsuarioIdAlteracao);

            if (!EmpresaValida(empresa)) return;

            var documentoValidation = CNPJValidation.Validar(empresa.NumeroDocumento);

            if (!documentoValidation)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CNPJ informado está inválido!"));
                return;
            }

            if (!EmailValidation.Validate(empresa.Email))
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Email informado está inválido!"));
                return;
            }

            if (!EmpresaExistente(message.Id, message.MessageType)) return;


            _empresaRepository.Atualizar(empresa);

            if (Commit())
            {
                _bus.RaiseEvent(new EmpresaRegistradaEvent(empresa.RazaoSocial, empresa.NomeFantasia,
                    empresa.NumeroDocumento, empresa.Bloqueado, empresa.Excluido, empresa.Email, empresa.Email2,
                    empresa.Email3, empresa.Cep, empresa.Bairro, empresa.Endereco, empresa.Uf, empresa.Cidade,
                    empresa.Contato, empresa.Contato2, empresa.Ddd, empresa.Telefone, empresa.Ddd2, empresa.Telefone2,
                    empresa.Ddd3, empresa.Telefone3, empresa.QuantidadeFilial, empresa.DiasParaExpiracaoPontos,
                    empresa.ValorComissãoGeral, empresa.PorcentagemPadraoPontos, empresa.DataCriacao,
                    empresa.DataAlteracao, empresa.UsuarioIdCriacao, empresa.UsuarioIdAlteracao));
            }
        }

        public void Handle(ExcluirEmpresaCommand message)
        {
        }

        public void Handle(DesativarEmpresaCommand message)
        {
            var empresa = Empresas.EmpresaFactory.EmpresaCompleta(message.Id, message.RazaoSocial, message.NomeFantasia,
                message.NumeroDocumento, message.Bloqueado, message.Excluido, message.Email, message.Email2,
                message.Email3, message.Cep, message.Bairro, message.Endereco, message.Latitude, message.Longitude,
                message.Ramo, message.ProfissionalLiberal, message.Plano, message.Uf, message.Cidade,
                message.Contato, message.Contato2, message.Ddd, message.Telefone, message.Ddd2, message.Telefone2,
                message.Ddd3, message.Telefone3, message.QuantidadeFilial, message.DiasParaExpiracaoPontos,
                message.ValorComissãoGeral, message.PorcentagemPadraoPontos, message.DataCriacao, message.DataAlteracao,
                message.UsuarioIdCriacao, message.UsuarioIdAlteracao);

            if (!EmpresaExistente(message.Id, message.MessageType)) return;

//            if (!EmpresaValida(empresa)) return;

            _empresaRepository.Atualizar(empresa);

            if (Commit())
            {
                _bus.RaiseEvent(new EmpresaRegistradaEvent(empresa.RazaoSocial, empresa.NomeFantasia,
                    empresa.NumeroDocumento, empresa.Bloqueado, empresa.Excluido, empresa.Email, empresa.Email2,
                    empresa.Email3, empresa.Cep, empresa.Bairro, empresa.Endereco, empresa.Uf, empresa.Cidade,
                    empresa.Contato, empresa.Contato2, empresa.Ddd, empresa.Telefone, empresa.Ddd2, empresa.Telefone2,
                    empresa.Ddd3, empresa.Telefone3, empresa.QuantidadeFilial, empresa.DiasParaExpiracaoPontos,
                    empresa.ValorComissãoGeral, empresa.PorcentagemPadraoPontos, empresa.DataCriacao,
                    empresa.DataAlteracao, empresa.UsuarioIdCriacao, empresa.UsuarioIdAlteracao));
            }
        }

        public void Handle(ReativarEmpresaCommand message)
        {
            var empresa = Empresas.EmpresaFactory.EmpresaCompleta(message.Id, message.RazaoSocial, message.NomeFantasia,
                message.NumeroDocumento, message.Bloqueado, message.Excluido, message.Email, message.Email2,
                message.Email3, message.Cep, message.Bairro, message.Endereco, message.Latitude, message.Longitude,
                message.Ramo, message.ProfissionalLiberal, message.Plano, message.Uf, message.Cidade,
                message.Contato, message.Contato2, message.Ddd, message.Telefone, message.Ddd2, message.Telefone2,
                message.Ddd3, message.Telefone3, message.QuantidadeFilial, message.DiasParaExpiracaoPontos,
                message.ValorComissãoGeral, message.PorcentagemPadraoPontos, message.DataCriacao, message.DataAlteracao,
                message.UsuarioIdCriacao, message.UsuarioIdAlteracao);

            if (!EmpresaExistente(message.Id, message.MessageType)) return;

//            if (!EmpresaValida(empresa)) return;

            _empresaRepository.Atualizar(empresa);

            if (Commit())
            {
                _bus.RaiseEvent(new EmpresaRegistradaEvent(empresa.RazaoSocial, empresa.NomeFantasia,
                    empresa.NumeroDocumento, empresa.Bloqueado, empresa.Excluido, empresa.Email, empresa.Email2,
                    empresa.Email3, empresa.Cep, empresa.Bairro, empresa.Endereco, empresa.Uf, empresa.Cidade,
                    empresa.Contato, empresa.Contato2, empresa.Ddd, empresa.Telefone, empresa.Ddd2, empresa.Telefone2,
                    empresa.Ddd3, empresa.Telefone3, empresa.QuantidadeFilial, empresa.DiasParaExpiracaoPontos,
                    empresa.ValorComissãoGeral, empresa.PorcentagemPadraoPontos, empresa.DataCriacao,
                    empresa.DataAlteracao, empresa.UsuarioIdCriacao, empresa.UsuarioIdAlteracao));
            }
        }

        private bool EmpresaValida(Empresas empresa)
        {
            if (empresa.IsValid()) return true;

            NotificarValidacoesErro(empresa.ValidationResult);
            return false;
        }

        private bool EmpresaExistente(int id, string messageType)
        {
            var empresa = _empresaRepository.ObterPorId(id);

            if (empresa != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Beneficiario não encontrado."));
            return false;
        }
    }
}