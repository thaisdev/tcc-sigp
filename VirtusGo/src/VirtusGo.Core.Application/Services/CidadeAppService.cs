using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Cidade;
using VirtusGo.Core.Domain.Cidade.Commands;
using VirtusGo.Core.Domain.Cidade.Repository;
using VirtusGo.Core.Domain.Core.Bus;

namespace VirtusGo.Core.Application.Services
{
    public class CidadeAppService : ICidadeAppService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public CidadeAppService(ICidadeRepository cidadeRepository, IMapper mapper, IBus bus)
        {
            _cidadeRepository = cidadeRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(CidadeViewModel cidadeViewModel)
        {
            var command = _mapper.Map<RegistrarCidadeCommand>(cidadeViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(CidadeViewModel cidadeViewModel)
        {
            var command = _mapper.Map<AtualizarCidadeCommand>(cidadeViewModel);
            _bus.SendCommand(command);
        }

        public void Excluir(int id)
        {
            var model = _cidadeRepository.ObterPorId(id);
            var t = new CidadeViewModel
            {
                Id = id,
                EstadoId = model.EstadoId,
                NomeCidade = model.NomeCidade,
            };
            var command = _mapper.Map<RemoverCIdadeCommand>(t);
            _bus.SendCommand(command);
        }

        public IEnumerable<CidadeViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(_cidadeRepository.ObterTodos());
        }

        public IEnumerable<CidadeViewModel> ObterTodosQueriable()
        {
            return _mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(
                _cidadeRepository.ObterTodosQueriable());
        }
    }
}