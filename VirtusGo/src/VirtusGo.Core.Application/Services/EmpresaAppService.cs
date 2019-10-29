using System;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Empresas.Commands;
using VirtusGo.Core.Domain.Empresas.Repository;
using VirtusGo.Core.Domain.Estado.Commands;

namespace VirtusGo.Core.Application.Services
{
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly IEmpresaRepository _estadoRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public EmpresaAppService(IEmpresaRepository estadoRepository, IMapper mapper, IBus bus)
        {
            _estadoRepository = estadoRepository;
            _mapper = mapper;
            _bus = bus;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(EmpresaViewModel empresaViewModel)
        {
            var command = _mapper.Map<RegistrarEmpresaCommand>(empresaViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(EmpresaViewModel empresaViewModel)
        {
            var command = _mapper.Map<AtualizarEmpresaCommand>(empresaViewModel);
            _bus.SendCommand(command);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}