using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.CaixaFornecedor.Commands;
using VirtusGo.Core.Domain.CaixaFornecedor.Repository;
using VirtusGo.Core.Domain.Core.Bus;

namespace VirtusGo.Core.Application.Services
{
    public class CaixaFornecedorAppService : ICaixaFornecedorAppService
    {
        private readonly ICaixaFornecedorRepository _caixaFornecedorRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public CaixaFornecedorAppService(ICaixaFornecedorRepository caixaFornecedorRepository, IMapper mapper, IBus bus)
        {
            _caixaFornecedorRepository = caixaFornecedorRepository;
            _mapper = mapper;
            _bus = bus;
        }
        public void Adicionar(CaixaFornecedorViewModel caixaFornecedorViewModel)
        {
            var command = _mapper.Map<RegistrarCaixaFornecedorCommand>(caixaFornecedorViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(CaixaFornecedorViewModel caixaFornecedorViewModel)
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
