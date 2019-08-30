using Microsoft.AspNetCore.Identity;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.UI.Mvc.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string EmailSupervisor { get; set; }
        public PerfilUsuarioEnum PefilUsuario { get; set; }
        public int? EmpresaId { get; set; }
        public int? UnidadeId { get; set; }
        public string Cpf { get; set; }
    }

    //public static class IdentityExtensions
    //{
    //    public static string GetUserImage(this IIdentity identity)
    //    {
    //        var claim = ((ClaimsIdentity)identity).FindFirst("Imagem");
    //        // Test for null to avoid issues during local testing
    //        return (claim != null) ? claim.Value : string.Empty;
    //    }

    //}
}
