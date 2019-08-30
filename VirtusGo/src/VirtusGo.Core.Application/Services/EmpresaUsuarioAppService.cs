using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.EmpresaUsuarios;
using VirtusGo.Core.Domain.EmpresaUsuarios.Command;
using VirtusGo.Core.Domain.EmpresaUsuarios.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class EmpresaUsuarioAppService : IEmpresaUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IBus _bus;
        private readonly IEmpresaUsuarioRepository _empresaUsuarioRepository;

        public EmpresaUsuarioAppService(IMapper mapper, IBus bus, IEmpresaUsuarioRepository empresaUsuarioRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _empresaUsuarioRepository = empresaUsuarioRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public EmpresaUsuarioViewModel Adicionar(EmpresaUsuarioViewModel empresaUsuarioViewModel)
        {
            var command = _mapper.Map<RegistrarEmpresaUsuariosCommand>(empresaUsuarioViewModel);
            
            _bus.SendCommand(command);
            return empresaUsuarioViewModel;
        }

        public IEnumerable<EmpresaUsuarioViewModel> ObterTodos()
        {
            return _mapper.Map<List<EmpresaUsuarioViewModel>>(_empresaUsuarioRepository.ObterTodos());
        }
    }
}