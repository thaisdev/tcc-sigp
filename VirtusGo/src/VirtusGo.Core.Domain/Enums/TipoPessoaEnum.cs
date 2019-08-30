using System.ComponentModel.DataAnnotations;

namespace VirtusGo.Core.Domain.Enums
{
    public enum TipoPessoaEnum
    {
        [Display(Name = "Pessoa Física")]
        Pf = 1,

        [Display(Name = "Pessoa Jurídica")]
        Pj = 2,

        [Display(Name = "Estudante")]
        E = 3
    }
}