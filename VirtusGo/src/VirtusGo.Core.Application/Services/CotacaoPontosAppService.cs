using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.CotacaoPontos.Commands;
using VirtusGo.Core.Domain.CotacaoPontos.Repository;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Application.Services
{
    public class CotacaoPontosAppService : ICotacaoPontosAppService
    {
        private readonly ICotacaoPontosRepository _cotacaoPontosRepository;
        private readonly IBus _bus;
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public CotacaoPontosAppService(ICotacaoPontosRepository cotacaoPontosRepository, IBus bus, IUser user, IMapper mapper)
        {
            _cotacaoPontosRepository = cotacaoPontosRepository;
            _bus = bus;
            _user = user;
            _mapper = mapper;
        }

        public void Dispose()
        {
            _cotacaoPontosRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<CotacaoPontosViewModel> ObterTodosQueriable()
        {
            return _mapper.Map<List<CotacaoPontosViewModel>>(_cotacaoPontosRepository.ObterTodosQueriable());
        }

        public CotacaoPontosViewModel Adicionar(CotacaoPontosViewModel cotacaoPontosViewModel)
        {
            var command = _mapper.Map<RegistrarCotacaoPontosCommand>(cotacaoPontosViewModel);

            _bus.SendCommand(command);
            return cotacaoPontosViewModel;
        }

        public CotacaoPontosViewModel Atualizar(CotacaoPontosViewModel cotacao)
        {
            throw new NotImplementedException();
        }

        public CotacaoPontosViewModel ObterPorCotacaoId(int id)
        {
            return _mapper.Map<CotacaoPontosViewModel>(_cotacaoPontosRepository.ObterPorCotacaoId(id));
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public CotacaoPontosViewModel Desativar(int id)
        {
            var cotacaoPontosViewModel = _mapper.Map<CotacaoPontosViewModel>(_cotacaoPontosRepository.ObterPorCotacaoId(id));
            cotacaoPontosViewModel.FlagExcluido = FlagExcluidoEnum.sim;
            cotacaoPontosViewModel.DataAlteracao = DateTime.Now;
            cotacaoPontosViewModel.UsuarioIdAlteracao = _user.GetUserId();
            
            var command = _mapper.Map<AtualizarCotacaoPontosCommand>(cotacaoPontosViewModel);
            _bus.SendCommand(command);
            
            return cotacaoPontosViewModel;
        }
    }
}