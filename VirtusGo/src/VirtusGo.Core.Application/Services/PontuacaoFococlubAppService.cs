using System;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.PontuacaoFocoClub.Commands;

namespace VirtusGo.Core.Application.Services
{
    public class PontuacaoFococlubAppService : IPontuacaoFococlubAppService
    {
        private readonly IMapper _mapper;
        private readonly IUser _user;
        private readonly IBus _bus;

        public PontuacaoFococlubAppService(IMapper mapper, IUser user, IBus bus)
        {
            _mapper = mapper;
            _user = user;
            _bus = bus;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PontuacaoFococlubViewModel Adicionar(PontuacaoFococlubViewModel pontuacaoFococlubViewModel)
        {
            var command = _mapper.Map<RegistrarPontuacaoFococlubCommand>(pontuacaoFococlubViewModel);

            _bus.SendCommand(command);
            return pontuacaoFococlubViewModel;
        }

        public PontuacaoFococlubViewModel Atualizar(PontuacaoFococlubViewModel pontuacaoFococlubViewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}