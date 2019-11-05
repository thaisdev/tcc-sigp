using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Produtos.Repository;

namespace VirtusGo.Core.Domain.Produtos.Commands
{
    public class ProdutoCommandHandler : CommandHandler, IHandler<AtualizarProdutoCommand>,
        IHandler<ExcluirProdutoCommand>, IHandler<RegistrarProdutoCommand>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public ProdutoCommandHandler(IUnitOfWork uow, IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            IProdutoRepository produtoRepository) : base(uow, bus, notifications)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        public void Handle(AtualizarProdutoCommand message)
        {
            var produto = Produto.ProdutoFactory.ProdutoCompleto(message.Id, message.Descricao, message.Unidade,
                message.ValorUnitario, message.Estoque, message.NCM);

            _produtoRepository.Adicionar(produto);
        }

        public void Handle(ExcluirProdutoCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(RegistrarProdutoCommand message)
        {
            var produto = Produto.ProdutoFactory.ProdutoCompleto(message.Id, message.Descricao, message.Unidade,
                message.ValorUnitario, message.Estoque, message.NCM);

            if (!ModelValidate(produto)) return;

            _produtoRepository.Adicionar(produto);

            if (Commit())
            {
            }
        }

        private bool ModelValidate(Produto produto)
        {
            if (produto.IsValid()) return true;

            NotificarValidacoesErro(produto.ValidationResult);
            return false;
        }
    }
}