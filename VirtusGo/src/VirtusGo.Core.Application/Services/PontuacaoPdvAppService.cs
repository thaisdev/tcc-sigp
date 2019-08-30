using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.PontuacaoPdv.Commands;
using VirtusGo.Core.Domain.PontuacaoPdv.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class PontuacaoPdvAppService : IPontuacaoPdvAppService
    {
        private readonly IBus _bus;
        private readonly IUser _user;
        private readonly IMapper _mapper;
        private readonly IPontuacaoPDVRepository _pontuacaoPdvRepository;


        public PontuacaoPdvAppService(IBus bus, IUser user, IMapper mapper, IPontuacaoPDVRepository pontuacaoPdvRepository)
        {
            _bus = bus;
            _user = user;
            _mapper = mapper;
            _pontuacaoPdvRepository = pontuacaoPdvRepository;
        }

        public void Dispose()
        {
            _pontuacaoPdvRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<PontuacaoPdvViewModel> ObterTodosQueriable()
        {
            throw new NotImplementedException();
        }

        public PontuacaoPdvViewModel Excluir(int id)
        {
            var pdv = _mapper.Map<PontuacaoPdvViewModel>(_pontuacaoPdvRepository.ObterPorPontuacaoPDVId(id));
            pdv.FlagExcluido = FlagExcluidoEnum.sim;

            var command = _mapper.Map<ExcluirPdvCommand>(pdv);
            _bus.SendCommand(command);
            return null;
        }

        public List<PontuacaoPdvViewModel> ObterTodosAtivos()
        {
            return Mapper.Map<List<PontuacaoPdvViewModel>>(_pontuacaoPdvRepository.ObterTodosAtivos());
        }

        public List<PontuacaoPdvViewModel> ObterTodosAtivosPorUnidadeId(int id)
        {
            return Mapper.Map<List<PontuacaoPdvViewModel>>(_pontuacaoPdvRepository.ObterTodosAtivosPorUnidadeId(id));
        }

        public PontuacaoPdvViewModel ObterPontuacaoPdvPorId(int id)
        {
            return _mapper.Map<PontuacaoPdvViewModel>(_pontuacaoPdvRepository.ObterPorPontuacaoPDVId(id));
        }

        public void AprovarPorId(int id)
        {
            var pontuacaoPdvViewModel =
                _mapper.Map<PontuacaoPdvViewModel>(_pontuacaoPdvRepository.ObterPorPontuacaoPDVId(id));
            
            pontuacaoPdvViewModel.FlagInterface = "1";
            pontuacaoPdvViewModel.UsuarioIdInterface = _user.GetUserId();
            pontuacaoPdvViewModel.DataInterface = DateTime.Now;

            var command = _mapper.Map<AprovarPdvCommand>(pontuacaoPdvViewModel);
            _bus.SendCommand(command);
        }
    }
}