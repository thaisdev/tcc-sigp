using System;

namespace VirtusGo.Core.Application.ViewModels
{
    public class OrdemCargaViewModel
    {
        public int Id { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataChegada { get; set; }
        public int RotaId { get; set; }
        public int MotoristaId { get; set; }
        public int VeiculoId { get; set; }
    }
}