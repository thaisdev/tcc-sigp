using System.ComponentModel.DataAnnotations;

namespace VirtusGo.Core.Domain.Enums
{
    public enum PerfilUsuarioEnum
    {
        [Display(Name = "Administrador")]
        Administrador = 1,

        [Display(Name = "Gerente")]
        Gerente = 2,

        [Display(Name = "Operador")]
        Operador = 3,

        [Display(Name = "Operador_Unidades")]
        Operador_Unidades = 4,

    }
}