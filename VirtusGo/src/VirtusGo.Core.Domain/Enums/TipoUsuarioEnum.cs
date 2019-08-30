using System.ComponentModel.DataAnnotations;

namespace VirtusGo.Core.Domain.Enums
{
    public enum TipoUsuarioEnum
    {
        [Display(Name = "Pessoa Física")]
        Pf,

        [Display(Name = "Pesso Jurídica")]
        Pj
    }
}