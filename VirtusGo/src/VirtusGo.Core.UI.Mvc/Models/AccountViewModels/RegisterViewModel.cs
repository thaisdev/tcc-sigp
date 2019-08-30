using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.UI.Mvc.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Informe sua Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme sua Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        [Display(Name = "Email Supervisor")]
        public string EmailSupervisor { get; set; }

        [Required(ErrorMessage = "Escolha um Pefil para este usuario")]
        public PerfilUsuarioEnum PefilUsuario { get; set; }

        public int? EmpresaId { get; set; }
        
        public int? UnidadeId { get; set; }

        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório.")]
        public string Cpf { get; set; }

        [NotMapped]
        public List<string> Empresas { get; set; }
    }
}
