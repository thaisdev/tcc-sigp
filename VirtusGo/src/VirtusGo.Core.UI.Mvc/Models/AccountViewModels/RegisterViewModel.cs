using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.UI.Mvc.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public PerfilUsuarioEnum PefilUsuario { get; set; }

        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
