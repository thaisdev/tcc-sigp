using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Beneficiarios.Commands;
using VirtusGo.Core.Domain.Beneficiarios.Repository;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class BeneficiarioAppService : IBeneficiarioAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IBeneficiarioRepository _beneficiarioRepository;
        private readonly IUser _user;

        public BeneficiarioAppService(IBus bus, IMapper mapper, IBeneficiarioRepository beneficiarioRepository, IUser user)
        {
            _bus = bus;
            _mapper = mapper;
            _beneficiarioRepository = beneficiarioRepository;
            _user = user;
        }
        
        public void Dispose()
        {
            _beneficiarioRepository.Dispose();
        }

        public BeneficiarioViewModel ObterPorCpf(string cpf)
        {
            return _mapper.Map<BeneficiarioViewModel>(_beneficiarioRepository.ObterPorCpf(cpf));     
        }

        public BeneficiarioViewModel ObterPorBeneficiarioId(int id)
        {
            return _mapper.Map<BeneficiarioViewModel>(_beneficiarioRepository.ObterPorId(id));
        }

        public List<BeneficiarioViewModel> ObterTodosQueriable()
        {
            return _mapper.Map<List<BeneficiarioViewModel>>(_beneficiarioRepository.ObterTodos());
        }

        public BeneficiarioViewModel Adicionar(BeneficiarioViewModel beneficiarioViewModel)
        {
            beneficiarioViewModel.DataCadastro = DateTime.Now;
            var registroCommand = _mapper.Map<RegistrarBeneficiarioCommand>(beneficiarioViewModel);
            _bus.SendCommand(registroCommand);
            return beneficiarioViewModel;
        }

        public BeneficiarioViewModel ObterPorEmail(string email)
        {
            return _mapper.Map<BeneficiarioViewModel>(_beneficiarioRepository.ObterPorEmail(email));
        }

        public IEnumerable<BeneficiarioViewModel> ObterTodosAtivos()
        {
            return _mapper.Map<IEnumerable<BeneficiarioViewModel>>(_beneficiarioRepository.ObterTodosAtivos());
        }

        public IEnumerable<BeneficiarioViewModel> ObterTodosInativos()
        {
            return _mapper.Map<IEnumerable<BeneficiarioViewModel>>(_beneficiarioRepository.ObterTodosInativos());
        }

        public BeneficiarioViewModel Atualizar(BeneficiarioViewModel beneficiarioViewModel)
        {
            //TODO: Validar
            var atualizarBeneficiarioCommand = _mapper.Map<AtualizarBeneficiarioCommand>(beneficiarioViewModel);
            _bus.SendCommand(atualizarBeneficiarioCommand);
            return beneficiarioViewModel;
        }

        public void Remover(int id)
        {
            _bus.SendCommand(new ExcluirBeneficiarioCommand(id));
        }

        public BeneficiarioViewModel DesativarPorId(BeneficiarioViewModel beneficiarioViewModel)
        {
            beneficiarioViewModel.Excluido = FlagExcluidoEnum.sim;
            var desativarCommand = _mapper.Map<DesativarBeneficiarioCommand>(beneficiarioViewModel);
            _bus.SendCommand(desativarCommand);
            return beneficiarioViewModel;
        }

        public BeneficiarioViewModel ReativarPorId(int id)
        {
            var beneficiarioViewModel = _mapper.Map<BeneficiarioViewModel>(_beneficiarioRepository.ObterPorId(id));
            beneficiarioViewModel.Excluido = FlagExcluidoEnum.nao;
            beneficiarioViewModel.UsuarioAlteracaoId = _user.GetUserId();
            beneficiarioViewModel.DataAlteracao = DateTime.Now;
            var reativarCommand = _mapper.Map<ReativarBeneficiarioCommand>(beneficiarioViewModel);
            _bus.SendCommand(reativarCommand);
            return beneficiarioViewModel;
        }

        public IEnumerable<BeneficiarioViewModel> ObterTodosAtivosSelect()
        {
            return _mapper.Map<IEnumerable<BeneficiarioViewModel>>(_beneficiarioRepository.ObterTodosAtivosSelect());
        }
    }
}