using System;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.CondicaoFinanceira.Commands;
using VirtusGo.Core.Domain.CondicaoFinanceira.Repository;
using VirtusGo.Core.Domain.Core.Bus;

namespace VirtusGo.Core.Application.Services
{
    public class CondicaoFinanceiraAppService : ICondicaoFinanceiraAppService
    {
        private readonly ICondicaoFinanceiraRepository _condicaoFinanceiraRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public CondicaoFinanceiraAppService(ICondicaoFinanceiraRepository condicaoFinanceiraRepository, IMapper mapper,
            IBus bus)
        {
            _condicaoFinanceiraRepository = condicaoFinanceiraRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(CondicaoFinanceiraViewModel condicaoFinanceiraViewModel)
        {
            var command = _mapper.Map<RegistrarCondicaoFinanceiraCommand>(condicaoFinanceiraViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(CondicaoFinanceiraViewModel condicaoFinanceiraViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}