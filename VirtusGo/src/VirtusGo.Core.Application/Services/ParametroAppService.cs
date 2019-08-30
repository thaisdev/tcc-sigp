using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Parametro.Command;
using VirtusGo.Core.Domain.Parametro.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class ParametroAppService : IParametroAppService
    {
        private readonly IParametroRepository _parametroRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public ParametroAppService(IUnitOfWork uow, IParametroRepository parametroRepository, IMapper mapper, IBus bus)
        {
            _parametroRepository = parametroRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            _parametroRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public ParametrosViewModel Adicionar(ParametrosViewModel parametrosViewModel)
        {
            return parametrosViewModel;
        }

        public ParametrosViewModel Atualizar(ParametrosViewModel parametrosViewModel)
        {
            var command = _mapper.Map<AtualizarParametroCommand>(parametrosViewModel);
            
            _bus.SendCommand(command);
            return parametrosViewModel;
        }

        public void Remover(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<ParametrosViewModel> ObterTodosQueriable()
        {
            return _mapper.Map<List<ParametrosViewModel>>(_parametroRepository.ObterTodosQueriable());
        }

        public List<ParametrosViewModel> ObterTodosAtivos()
        {
            return _mapper.Map<List<ParametrosViewModel>>(_parametroRepository.ObterTodosAtivo());
        }

        public ParametrosViewModel ObterParametroAtivo()
        {
            return _mapper.Map<ParametrosViewModel>(_parametroRepository.ObterParametroAtivo());
        }
    }
}