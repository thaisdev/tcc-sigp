using System.ComponentModel.DataAnnotations;

namespace VirtusGo.Core.Domain.Enums
{
    public enum FlagExcluidoEnum
    {
        [Display(Name = "Não")]
        nao = 0,
        [Display(Name = "Sim")]
        sim = 1
    }
}