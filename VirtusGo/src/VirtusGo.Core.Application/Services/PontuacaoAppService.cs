using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Pontuacao.Repository;
using VirtusGo.Core.Domain.Pontuacao.Commands;

namespace Virtus.Core.Application.Services
{
    public class PontuacaoAppService : IPontuacaoAppService
    {
        private readonly IBus _bus;
        private readonly IUser _user;
        private readonly IMapper _mapper;
        private readonly IPontuacaoRepository _pontuacaoRepository;

        public PontuacaoAppService(IBus bus, IUser user, IMapper mapper, IPontuacaoRepository pontuacaoRepository)
        {
            _bus = bus;
            _user = user;
            _mapper = mapper;
            _pontuacaoRepository = pontuacaoRepository;
        }

        public void Dispose()
        {
            _pontuacaoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public PontuacaoViewModel Adicionar(PontuacaoViewModel pontuacaoViewModel)
        {
            var command = _mapper.Map<RegistrarPontuacaoCommand>(pontuacaoViewModel);

            _bus.SendCommand(command);
            return pontuacaoViewModel;
        }

        public PontuacaoViewModel Atualizar(PontuacaoViewModel pontuacaoPdvViewModel)
        {
            throw new System.NotImplementedException();
        }

        public void DesativarPorId(int id)
        {
            var pontuacao = _mapper.Map<PontuacaoViewModel>(_pontuacaoRepository.ObterPorId(id));
            pontuacao.FlagInterface = "1";
            pontuacao.UsuarioIdInterface = _user.GetUserId();
            pontuacao.DataInterface = DateTime.Now;

            var command = _mapper.Map<DesativarPontuacaoCommand>(pontuacao);
            _bus.SendCommand(command);
        }

        public void Remover(int id)
        {
            _pontuacaoRepository.Remover(id);
        }

        public List<PontuacaoViewModel> ObterTodosAtivos()
        {
            return _mapper.Map<List<PontuacaoViewModel>>(_pontuacaoRepository.ObterTodosAtivos());
        }

        public List<PontuacaoViewModel> ObterTodosInativos()
        {
            return _mapper.Map<List<PontuacaoViewModel>>(_pontuacaoRepository.ObterTodosInativos());
        }

        public List<PontuacaoViewModel> ObterTodosAtivosPorEmpresaId(int id)
        {
            return _mapper.Map<List<PontuacaoViewModel>>(_pontuacaoRepository.ObterTodosAtivosPorEmpresaId(id));
        }

        public List<PontuacaoViewModel> ObterTodosAtivosPorBeneficiarioId(int id)
        {
            return _mapper.Map<List<PontuacaoViewModel>>(_pontuacaoRepository.ObterTodosAtivosPorBeneficiarioId(id));
        }

        public PontuacaoViewModel ObterPorId(int id)
        {
            return _mapper.Map<PontuacaoViewModel>(_pontuacaoRepository.ObterDadosPorId(id));
        }
    }
}