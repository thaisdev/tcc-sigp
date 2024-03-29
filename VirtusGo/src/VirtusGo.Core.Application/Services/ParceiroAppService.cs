using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Parceiro;
using VirtusGo.Core.Domain.Parceiro.Commands;
using VirtusGo.Core.Domain.Parceiro.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class ParceiroAppService : IParceiroAppService
    {
        private readonly IParceiroRepository _parceiroRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public ParceiroAppService(IParceiroRepository parceiroRepository, IMapper mapper, IBus bus)
        {
            _parceiroRepository = parceiroRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(ParceiroViewModel parceiroViewModel)
        {
            var command = _mapper.Map<RegistrarParceiroCommand>(parceiroViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(ParceiroViewModel parceiroViewModel)
        {
            var command = _mapper.Map<AtualizarParceiroCommand>(parceiroViewModel);
            _bus.SendCommand(command);
        }

        public void Excluir(int id)
        {
            var parceiro = _mapper.Map<Parceiro, ParceiroViewModel>(_parceiroRepository.ObterPorId(id));
            var command = _mapper.Map<ExcluirParceiroCommand>(parceiro);
            _bus.SendCommand(command);
        }

        public IEnumerable<ParceiroViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<Parceiro>, IEnumerable<ParceiroViewModel>>(_parceiroRepository.ObterTodos());
        }
    }
}