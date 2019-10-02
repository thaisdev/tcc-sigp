using System;
using VirtusGo.Core.Domain.Veiculo.Commands;

namespace VirtusGo.Core.Domain.OrdemCarga.Commands
{
    public class AtualizarOrdemCargaCommand : BaseOrdemCargaCommand
    {
        public AtualizarOrdemCargaCommand(int id, DateTime dataSaida, DateTime dataChegada, int rotaId, int motoristaId, int veiculoId)
        {
            Id = id;
            DataSaida = dataSaida;
            DataChegada = dataChegada;
            RotaId = rotaId;
            MotoristaId = motoristaId;
            VeiculoId = veiculoId;
        }
    }
}