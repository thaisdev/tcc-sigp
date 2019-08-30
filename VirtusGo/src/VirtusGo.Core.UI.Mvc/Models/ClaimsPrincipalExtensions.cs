using System;
using System.Security.Claims;

namespace VirtusGo.Core.UI.Mvc.Models
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claims = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claims?.Value;
        }

        public static string GetUserIamgeNovo(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claims = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claims?.Value;
        }
    }
}