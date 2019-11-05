using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Produtos;
using VirtusGo.Core.Domain.Produtos.Commands;
using VirtusGo.Core.Domain.Produtos.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public ProdutoAppService(IProdutoRepository produtoRepository, IMapper mapper, IBus bus)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(ProdutoViewModel produtoViewModel)
        {
            var command = _mapper.Map<RegistrarProdutoCommand>(produtoViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(ProdutoViewModel produtoViewModel)
        {
            var command = _mapper.Map<AtualizarProdutoCommand>(produtoViewModel);
            _bus.SendCommand(command);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoRepository.ObterTodos());
        }
    }
}