using System.ComponentModel.DataAnnotations;

namespace VirtusGo.Core.UI.Mvc.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
