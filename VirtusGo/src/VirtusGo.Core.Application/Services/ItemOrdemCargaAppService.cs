using System;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.ItemOrdemCarga;
using VirtusGo.Core.Domain.ItemOrdemCarga.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class ItemOrdemCargaAppService : IItemOrdemCargaAppService
    {
        private readonly IItemOrdemCargaRepository _itemOrdemCargaRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public ItemOrdemCargaAppService(IItemOrdemCargaRepository itemOrdemCargaRepository, IMapper mapper, IBus bus)
        {
            _itemOrdemCargaRepository = itemOrdemCargaRepository;
            _mapper = mapper;
            _bus = bus;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(ItemOrdemCargaViewModel itemOrdemCargaViewModel)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(ItemOrdemCargaViewModel itemOrdemCargaViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}