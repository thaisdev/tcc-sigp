using System.ComponentModel.DataAnnotations;

namespace VirtusGo.Core.Domain.Enums
{
    public enum PlanosParceiros
    {
        [Display(Name = "Diamante")] Diamante = 0,
        [Display(Name = "Ouro")] Ouro = 1,
        [Display(Name = "Prata")] Prata = 2,
        [Display(Name = "Bronze")] Bronze = 3
    }
}