using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.OrdemCarga;
using VirtusGo.Core.Domain.OrdemCarga.Commands;
using VirtusGo.Core.Domain.OrdemCarga.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class OrdemCargaAppService : IOrdemCargaAppService
    {
        private readonly IOrdemCargaRepository _ordemCargaRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public OrdemCargaAppService(IOrdemCargaRepository ordemCargaRepository, IMapper mapper, IBus bus)
        {
            _ordemCargaRepository = ordemCargaRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(OrdemCargaViewModel ordemCargaViewModel)
        {
            var command = _mapper.Map<RegistrarOrdemCargaCommand>(ordemCargaViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(OrdemCargaViewModel ordemCargaViewModel)
        {
            var command = _mapper.Map<AtualizarOrdemCargaCommand>(ordemCargaViewModel);
            _bus.SendCommand(command);
        }

        public void Excluir(int id)
        {
            var oc = _mapper.Map<OrdemCargaViewModel>(_ordemCargaRepository.ObterPorId(id));
            var command = _mapper.Map<ExcluirOrdemCargaCommand>(oc);
            _bus.SendCommand(command);
        }

        public IEnumerable<OrdemCargaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<OrdemCarga>, IEnumerable<OrdemCargaViewModel>>(_ordemCargaRepository
                .ObterTodos());
        }

        public IEnumerable<OrdemCargaViewModel> ObterTodosQueriable()
        {
            return _mapper.Map<IEnumerable<OrdemCarga>, IEnumerable<OrdemCargaViewModel>>(
                _ordemCargaRepository.ObterTodosQueriable());
        }
    }
}