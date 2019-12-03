using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VirtusGo.Core.Domain.Enums
{
    public enum FlagCompradorVendedorEnum
    {
        [Display(Name = "Não")]
        nao = 0,
        [Display(Name = "Sim")]
        sim = 1
    }
}
