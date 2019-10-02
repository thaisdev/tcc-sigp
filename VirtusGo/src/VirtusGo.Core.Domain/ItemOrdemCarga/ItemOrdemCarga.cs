using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.ItemOrdemCarga
{
    public class ItemOrdemCarga : Entity<ItemOrdemCarga>
    {
        public int OrdemCargaId { get; private set; }
        public int PedidoId { get; private set; }
        public int Sequencia { get; private set; }

        public ItemOrdemCarga(int id, int ordemCargaId, int pedidoId, int sequencia)
        {
            Id = id;
            OrdemCargaId = ordemCargaId;
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
                    OrdemCargaId = ordemCargaId,
                    PedidoId = pedidoId,
                    Sequencia = sequencia,
                };
                return itemOrdemCarga;
            }
        }
    }
}