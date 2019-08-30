using System.ComponentModel.DataAnnotations;

namespace VirtusGo.Core.Application.ViewModels
{
    public class EmpresaUsuarioViewModel
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaViewModel Empresa { get; set; }
    }
}