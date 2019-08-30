using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace VirtusGo.Core.UI.Mvc.Models
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public MyUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Imagem", user.Imagem ?? ""));
            identity.AddClaim(new Claim("Nome", user.Nome ?? ""));
            identity.AddClaim(new Claim("EmailSupervisor", user.EmailSupervisor ?? ""));
            identity.AddClaim(new Claim("Perfil", user.PefilUsuario.ToString() ?? ""));
            identity.AddClaim(new Claim("EmpresaId", user.EmpresaId.ToString() ?? ""));
            identity.AddClaim(user.UnidadeId.HasValue
                ? new Claim("UnidadeId", user.UnidadeId.ToString() ?? "")
                : new Claim("UnidadeId", 0.ToString() ?? ""));
            return identity;
        }
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
