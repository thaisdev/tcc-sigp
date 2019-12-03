using System;
using System.Collections.Generic;
using AutoMapper;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.ViewModels;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Endereco;
using VirtusGo.Core.Domain.Endereco.Commands;
using VirtusGo.Core.Domain.Endereco.Repository;

namespace VirtusGo.Core.Application.Services
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public EnderecoAppService(IEnderecoRepository enderecoRepository, IMapper mapper, IBus bus)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Adicionar(EnderecoViewModel enderecoViewModel)
        {
            var command = _mapper.Map<RegistrarEnderecoCommand>(enderecoViewModel);
            _bus.SendCommand(command);
        }

        public void Atualizar(EnderecoViewModel enderecoViewModel)
        {
            var command = _mapper.Map<AtualizarEnderecoCommand>(enderecoViewModel);
            _bus.SendCommand(command);
        }

        public void Excluir(int id)
        {
            var model = _enderecoRepository.ObterPorId(id);
            var t = new EnderecoViewModel
            {
                Id = id,
                Bairro = model.Bairro,
                Cep = model.Cep,
                Logradouro = model.Logradouro,
                Numero = model.Numero,
                CidadeId = model.CidadeId
            };
            var command = _mapper.Map<RemoverEnderecoCommand>(t);
            _bus.SendCommand(command);
        }

        public IEnumerable<EnderecoViewModel> ObterTodosQueriable()
        {
            return _mapper.Map<IEnumerable<Endereco>, IEnumerable<EnderecoViewModel>>(_enderecoRepository
                .ObterTodosQueriable());
        }
    }
}