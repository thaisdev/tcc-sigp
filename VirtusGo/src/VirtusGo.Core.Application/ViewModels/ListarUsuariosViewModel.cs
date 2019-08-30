using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Application.ViewModels
{
    public class ListarUsuariosViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public PerfilUsuarioEnum Perfil { get; set; }
        public bool LockoutEnabled { get; set; }
        public string UserId { get; set; }
    }
}