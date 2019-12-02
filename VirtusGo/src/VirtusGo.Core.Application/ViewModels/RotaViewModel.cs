using System.ComponentModel.DataAnnotations.Schema;

namespace VirtusGo.Core.Application.ViewModels
{
    public class RotaViewModel
    {
        public int Id { get; set; }
        public int EnderecoId { get; set; }
        
        [NotMapped] public EnderecoViewModel Endereco { get; set; }
    }
}