using AutoMapper;
using System;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.EnderecoEstoque.Commands;
using VirtusGo.Core.Domain.EnderecoEstoque.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class EnderecoEstoqueAppService : IEnderecoEstoqueAppService
    {
        private readonly IEnderecoEstoqueRepository _enderecoEstoqueRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public EnderecoEstoqueAppService(IEnderecoEstoqueRepository enderecoEstoqueRepository, IMapper mapper, IBus bus)
        {
            _enderecoEstoqueRepository = enderecoEstoqueRepository;
            _mapper = mapper;
            _bus = bus;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(EnderecoEstoqueViewModel enderecoEstoqueViewModel)
        {
            var command = _mapper.Map<RegistrarEnderecoEstoqueCommand>(enderecoEstoqueViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(EnderecoEstoqueViewModel enderecoEstoqueViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}