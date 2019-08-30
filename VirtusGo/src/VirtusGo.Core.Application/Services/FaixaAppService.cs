using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Faixas.Commands;
using VirtusGo.Core.Domain.Faixas.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class FaixaAppService : IFaixaAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IFaixaRepository _faixaRepository;
        public FaixaAppService(IMapper mapper, IBus bus, IFaixaRepository faixaRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _faixaRepository = faixaRepository;
        }

        public void Dispose()
        {
            _faixaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public FaixaViewModel Adicionar(FaixaViewModel faixaViewModel)
        {
            faixaViewModel.DataCriacao = DateTime.Now;
            faixaViewModel.FlagExcluido = FlagExcluidoEnum.nao;

            var command = _mapper.Map<RegistrarFaixaCommand>(faixaViewModel);
            _bus.SendCommand(command);

            return faixaViewModel;
        }

        public FaixaViewModel Atualizar(FaixaViewModel faixaViewModel)
        {
            faixaViewModel.DataAlteracao = DateTime.Now;
            
            var command = _mapper.Map<AtualizarFaixaCommand>(faixaViewModel);
            _bus.SendCommand(command);

            return faixaViewModel;
        }

        public void Excluir(FaixaViewModel faixaViewModel)
        {
            faixaViewModel.DataAlteracao = DateTime.Now;
            faixaViewModel.FlagExcluido = FlagExcluidoEnum.sim;
            
            var command = _mapper.Map<ExcluirFaixaCommand>(faixaViewModel);
            _bus.SendCommand(command);
        }

        public List<FaixaViewModel> ObterTodosQueriable()
        {
            return _mapper.Map<List<FaixaViewModel>>(_faixaRepository.ObterTodosAtivos());
        }

        public IEnumerable<FaixaViewModel> ObterTodosAtivos()
        {
            return _mapper.Map<IEnumerable<FaixaViewModel>>(_faixaRepository.ObterTodosAtivos());
        }

        public FaixaViewModel ObterPorId(int id)
        {
            return _mapper.Map<FaixaViewModel>(_faixaRepository.ObterPorId(id));
        }

        public IEnumerable<FaixaViewModel> ObterTodosAtivosPorEmpresaId(int id)
        {
            return _mapper.Map<IEnumerable<FaixaViewModel>>(_faixaRepository.ObterTodosAtivosPorEmpresaId(id));
        }
    }
}