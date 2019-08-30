using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Empresa.Commands;
using VirtusGo.Core.Domain.Empresa.Repository;
using VirtusGo.Core.Domain.EmpresaUsuarios.Repository;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly IBus _bus;
        private readonly IUser _user;
        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEmpresaUsuarioRepository _empresaUsuarioRepository;

        public EmpresaAppService(IBus bus, IUser user, IMapper mapper, IEmpresaRepository empresaRepository,
            IEmpresaUsuarioRepository empresaUsuarioRepository)
        {
            _bus = bus;
            _user = user;
            _mapper = mapper;
            _empresaRepository = empresaRepository;
            _empresaUsuarioRepository = empresaUsuarioRepository;
        }

        public void Dispose()
        {
            _empresaRepository.Dispose();
        }

        public EmpresaViewModel ObterPorCnpj(string cnpj)
        {
            return Mapper.Map<EmpresaViewModel>(_empresaRepository.ObterPorCnpj(cnpj));
        }

        public EmpresaViewModel Adicionar(EmpresaViewModel empresaViewModel)
        {
            var registroCommand = Mapper.Map<RegistrarEmpresaCommand>(empresaViewModel);

            _bus.SendCommand(registroCommand);
            return empresaViewModel;
        }

        public EmpresaViewModel Atualizar(EmpresaViewModel empresaViewModel)
        {
            var atualizarEmpresaCommand = Mapper.Map<AtualizarEmpresaCommand>(empresaViewModel);
            _bus.SendCommand(atualizarEmpresaCommand);
            return empresaViewModel;
        }

        public EmpresaViewModel ObterPorEmpresaId(int id)
        {
            return Mapper.Map<EmpresaViewModel>(_empresaRepository.ObterPorEmpresaId(id));
        }

        public IEnumerable<EmpresaViewModel> ObterTodosQueryable()
        {
            var data = _empresaRepository.ObterTodosQueriable();

            return Mapper.Map<List<EmpresaViewModel>>(data);
        }

        public IEnumerable<EmpresaViewModel> ObterTodosAtivos()
        {
            return Mapper.Map<List<EmpresaViewModel>>(_empresaRepository.ObterTodosAtivos());
        }

        public List<EmpresaViewModel> ObterTodosInativos()
        {
            return Mapper.Map<List<EmpresaViewModel>>(_empresaRepository.ObterTodosInativos());
        }

        public EmpresaViewModel Remover(int id)
        {
            throw new NotImplementedException();
        }

        public EmpresaViewModel Desativar(EmpresaViewModel empresaViewModel)
        {
            empresaViewModel.Excluido = FlagExcluidoEnum.sim;

            var desativarCommand = Mapper.Map<DesativarEmpresaCommand>(empresaViewModel);
            _bus.SendCommand(desativarCommand);
            return empresaViewModel;
        }

        public EmpresaViewModel Reativar(EmpresaViewModel empresaViewModel)
        {
            empresaViewModel.Excluido = FlagExcluidoEnum.nao;
            empresaViewModel.DataAlteracao = DateTime.Now;
            empresaViewModel.UsuarioIdAlteracao = _user.GetUserId();

            var desativarCommand = Mapper.Map<DesativarEmpresaCommand>(empresaViewModel);
            _bus.SendCommand(desativarCommand);
            return empresaViewModel;
        }

        public List<int> ObterEmpresasIdPorUsuario(int userId)
        {
            return _empresaUsuarioRepository.ObterTodos().Where(x => x.UsuarioId == userId).Select(x => x.EmpresaId)
                .ToList();
        }
    }
}