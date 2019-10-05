using System.Collections.Generic;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Pedidos;

namespace VirtusGo.Core.Domain.ItemOrdemCarga
{
    public class ItemOrdemCarga : Entity<ItemOrdemCarga>
    {
        public int PedidoId { get; private set; }
        public int Sequencia { get; private set; }

        //EF navigation
        public ICollection<Pedido> Pedidos { get; set; }

        public ItemOrdemCarga(int id, int ordemCargaId, int pedidoId, int sequencia)
        {
            Id = id;
            PedidoId = pedidoId;
            Sequencia = sequencia;
        }

        public ItemOrdemCarga()
        {
        }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarSequencia();
        }

        private void ValidarSequencia()
        {
            RuleFor(x => x.Sequencia).NotEmpty().WithMessage("Sequencia é obrigatório");
        }

        #endregion

        public static class ItemCargaFactory
        {
            public static ItemOrdemCarga ItemOrdemCargaCompleto(int id, int ordemCargaId, int pedidoId, int sequencia)
            {
                var itemOrdemCarga = new ItemOrdemCarga()
                {
                    Id = id,
                    PedidoId = pedidoId,
                    Sequencia = sequencia,
                };
                return itemOrdemCarga;
            }
        }
    }
}