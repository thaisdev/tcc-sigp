//using System;
//using System.Collections.Generic;
//using Virtus.Core.Application.ViewModels;

//namespace Virtus.Core.Application.Interfaces
//{
//    public interface IClienteAppService : IDisposable
//    {
//        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);
//        ClienteViewModel ObterPorId(Guid id);
//        ClienteViewModel ObterPorClienteId(int id);

//        ClienteViewModel ObterPorCpf(string cpf);
//        ClienteViewModel ObterPorEmail(string email);
//        IEnumerable<ClienteViewModel> ObterTodos();
//        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
//        void Remover(Guid id);

//        EnderecoViewModel AdicionarEndereco(EnderecoViewModel enderecoViewModel);
//        EnderecoViewModel AtualizarEndereco(EnderecoViewModel enderecoViewModel);
//        EnderecoViewModel ObterEnderecoPorId(Guid id);
//        void RemoverEndereco(Guid id);
//        ClienteViewModel ObterPorGuid(Guid id);
//    }
//}