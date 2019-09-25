using System;

namespace VirtusGo.Core.Domain.OrdemCarga.Commands
{
    public class RegistrarOrdemCargaCommand : BaseOrdemCargaCommand
    {
        public RegistrarOrdemCargaCommand(int id, DateTime dataSaida, DateTime dataChegada, int rotaId, int motoristaId, int veiculoId)
        {
            Id = id;
            DataSaida = dataSaida;
            DataChegada = dataChegada;
            RotaId = rotaId;
            MotoristaId = motoristaId;
            VeiculoId = veiculoId;

            AggregateId = Id;
        }
    }
}