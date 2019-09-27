using System.Collections.Generic;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.Rota
{
    public class Rota : Entity<Rota>
    {
        public Rota(int id, int enderecoId)
        {
            Id = id;
            EnderecoId = enderecoId;
        }

        private Rota()
        {
        }

        public int EnderecoId { get; private set; }

        //EF Navigation
        public ICollection<Endereco.Endereco> Endereco { get; set; }
        public OrdemCarga.OrdemCarga OrdemCarga { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region validacoes

        private void Validar()
        {
            ValidationResult = Validate(this);
        }

        #endregion

        public static class RotaFactory
        {
            public static Rota RotaCompleta(int id, int enderecoId)
            {
                var rota = new Rota()
                {
                    Id = id,
                    EnderecoId = enderecoId
                };

                return rota;
            }
        }
    }
}