using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.VendedorComprador.Commands;
using VirtusGo.Core.Domain.VendedorComprador.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class VendedorCompradorAppService : IVendedorCompradorAppService
    {
        private readonly IVendedorCompradorRepository _vendedorCompradorRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public VendedorCompradorAppService(IVendedorCompradorRepository vendedorCompradorRepository, IMapper mapper, IBus bus)
        {
            _vendedorCompradorRepository = vendedorCompradorRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Adicionar(VendedorCompradorViewModel vendedorCompradorViewModel)
        {
            var command = _mapper.Map<RegistrarVendedorCompradorCommand>(vendedorCompradorViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(VendedorCompradorViewModel vendedorCompradorViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
