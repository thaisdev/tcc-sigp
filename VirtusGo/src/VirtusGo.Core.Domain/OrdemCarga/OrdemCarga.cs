using System;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.OrdemCarga
{
    public class OrdemCarga : Entity<OrdemCarga>
    {
        public OrdemCarga(int id, DateTime dataSaida, DateTime dataChegada, int rotaId, int motoristaId, int veiculoId)
        {
            Id = id;
            DataSaida = dataSaida;
            DataChegada = dataChegada;
            RotaId = rotaId;
            MotoristaId = motoristaId;
            VeiculoId = veiculoId;
        }

        public OrdemCarga()
        {
        }

        public DateTime DataSaida { get; private set; }
        public DateTime DataChegada { get; private set; }
        public int RotaId { get; private set; }
        public int MotoristaId { get; private set; }
        public int VeiculoId { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarDataSaida();
        }

        private void ValidarDataSaida()
        {
            RuleFor(x => x.DataSaida).NotEmpty().WithMessage("Data de saída é obrigatório");
        }

        #endregion

        public static class OrdemCargaFactory
        {
            public  static OrdemCarga OrdemCargaCompleto(int id, DateTime dataSaida, DateTime dataChegada, int rotaId, int motoristaId, int veiculoId)
            {
                var ordemCarga = new OrdemCarga()
                {
                    Id = id,
                    DataSaida = dataSaida,
                    DataChegada = dataChegada,
                    RotaId = rotaId,
                    MotoristaId = motoristaId,
                    VeiculoId = veiculoId
                };
                return ordemCarga;
            }
        }
    }
}