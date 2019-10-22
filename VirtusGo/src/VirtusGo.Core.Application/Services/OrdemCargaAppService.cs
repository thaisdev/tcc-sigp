using System;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
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
            throw new NotImplementedException();
        }

        public void Atualizar(OrdemCargaViewModel ordemCargaViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}