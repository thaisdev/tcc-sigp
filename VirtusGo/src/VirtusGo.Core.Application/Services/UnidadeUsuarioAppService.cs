using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.UnidadeUsuarios.Commands;
using VirtusGo.Core.Domain.UnidadeUsuarios.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class UnidadeUsuarioAppService : IUnidadeUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IBus _bus;
        private readonly IUnidadeUsuarioRepository _unidadeUsuarioRepository;

        public UnidadeUsuarioAppService(IBus bus, IMapper mapper, IUnidadeUsuarioRepository unidadeUsuarioRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _unidadeUsuarioRepository = unidadeUsuarioRepository;
        }

        public UnidadeUsuarioViewModel Adicionar(UnidadeUsuarioViewModel unidadeUsuarioViewModel)
        {
            var command = _mapper.Map<RegistrarUnidadeUsuariosCommand>(unidadeUsuarioViewModel);
            _bus.SendCommand(command);
            return unidadeUsuarioViewModel;
        }

        public List<UnidadeUsuarioViewModel> ObterTodos()
        {
            return _mapper.Map<List<UnidadeUsuarioViewModel>>(_unidadeUsuarioRepository.ObterTodos());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}