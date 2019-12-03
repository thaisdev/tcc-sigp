using System.ComponentModel.DataAnnotations.Schema;

namespace VirtusGo.Core.Application.ViewModels
{
    public class CidadeViewModel
    {
        public int Id { get; set; }
        public string NomeCidade { get; set; }
        public int EstadoId { get; set; }

        [NotMapped] public EstadoViewModel Estado { get; set; }
    }
}