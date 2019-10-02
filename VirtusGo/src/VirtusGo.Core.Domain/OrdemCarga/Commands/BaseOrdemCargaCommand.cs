using System;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.OrdemCarga.Commands
{
    public class BaseOrdemCargaCommand : Command
    {
        public int Id { get; protected set; }
        public DateTime DataSaida { get; protected set; }
        public DateTime DataChegada { get; protected set; }
        public int RotaId { get; protected set; }
        public int MotoristaId { get; protected set; }
        public int VeiculoId { get; protected set; }
    }
}