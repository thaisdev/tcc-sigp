using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Pontuacao.Commands;
using VirtusGo.Core.Domain.Unidades.Commands;
using VirtusGo.Core.Domain.Unidades.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class UnidadeAppService : IUnidadeAppService
    {
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public UnidadeAppService(IUnidadeRepository unidadeRepository, IBus bus, IUser user)
        {
            _unidadeRepository = unidadeRepository;
            _bus = bus;
            _user = user;
        }

        public void Dispose()
        {
            _unidadeRepository.Dispose();
        }

        public UnidadeViewModel ObterPorCnpj(string cnpj)
        {
            return Mapper.Map<UnidadeViewModel>(_unidadeRepository.ObterPorCnpj(cnpj));
        }

        public List<UnidadeViewModel> ObterTodosQueriable()
        {
            var data = _unidadeRepository.ObterTodosAtivos();
            return Mapper.Map<List<UnidadeViewModel>>(data);
        }

        public List<UnidadeViewModel> ObterTodosAtivos()
        {
            return Mapper.Map<List<UnidadeViewModel>>(_unidadeRepository.ObterTodosAtivos());
        }

        public List<UnidadeViewModel> ObterTodosInativos()
        {
            return Mapper.Map<List<UnidadeViewModel>>(_unidadeRepository.ObterTodosInativos());
        }

        public UnidadeViewModel ObterPorUnidadeId(int id)
        {
            return Mapper.Map<UnidadeViewModel>(_unidadeRepository.ObterPorUnidadeId(id));
        }

        public UnidadeViewModel Adicionar(UnidadeViewModel unidadesViewModel)
        {
            var registroCommand = Mapper.Map<RegistrarUnidadeCommand>(unidadesViewModel);

            _bus.SendCommand(registroCommand);
            return unidadesViewModel;
        }

        public UnidadeViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<UnidadeViewModel>(_unidadeRepository.ObterPorEmail(email));
        }

        public UnidadeViewModel Atualizar(UnidadeViewModel unidadesViewModel)
        {
            var atualizarUnidadeCommand = Mapper.Map<AtualizarUnidadeCommand>(unidadesViewModel);
            _bus.SendCommand(atualizarUnidadeCommand);
            return unidadesViewModel;
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

        public UnidadeViewModel Desativar(int id)
        {
            var unidadeViewModel = Mapper.Map<UnidadeViewModel>(_unidadeRepository.ObterPorUnidadeId(id));
            unidadeViewModel.FlagExcluido = FlagExcluidoEnum.sim;
            unidadeViewModel.FlagBloqueado = FlagBloqueadoEnum.sim;
            unidadeViewModel.UsuarioIdAltera = _user.GetUserId();
            unidadeViewModel.DataAlteracao = DateTime.Now;

            var desativarUnidadeCommand = Mapper.Map<DesativarUnidadeCommand>(unidadeViewModel);
            _bus.SendCommand(desativarUnidadeCommand);
            return unidadeViewModel;
        }

        public UnidadeViewModel Reativar(int id)
        {
            var unidadeViewModel = Mapper.Map<UnidadeViewModel>(_unidadeRepository.ObterPorUnidadeId(id));
            unidadeViewModel.FlagExcluido = FlagExcluidoEnum.nao;
            unidadeViewModel.FlagBloqueado = FlagBloqueadoEnum.nao;
            unidadeViewModel.UsuarioIdAltera = _user.GetUserId();
            unidadeViewModel.DataAlteracao = DateTime.Now;

            var reativarUnidadeCommand = Mapper.Map<ReativarUnidadeCommand>(unidadeViewModel);
            _bus.SendCommand(reativarUnidadeCommand);
            return unidadeViewModel;
        }

        public List<UnidadeViewModel> ObterTodosAtivosPorEmpresa(int id)
        {
            return Mapper.Map<List<UnidadeViewModel>>(_unidadeRepository.ObterTodosAtivosPorEmpresa(id));
        }

        public IEnumerable<UnidadeViewModel> ObterTodosInativosPorEmpresa(int empresaId)
        {
            return Mapper.Map<IEnumerable<UnidadeViewModel>>(_unidadeRepository.ObterTodosInativosPorEmpresa(empresaId));
        }
    }
}