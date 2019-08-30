using System;
using System.ComponentModel.DataAnnotations;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Application.ViewModels
{
    public class ParametrosViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Dias para Expiração dos Pontos")]
        public int DiasParaExpiracaoPontos { get; set; }
        [Required(ErrorMessage = "Comissão Geral dos Pontos")]
        public double ValorComissaoGeral { get; set; }
        public FlagExcluidoEnum FlagExcluido { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int UsuarioIdCriacao { get; set; }
        public int? UsuarioIdAlteracao { get; set; }
//        public virtual Usuario Usuario { get; set; }
        //Porcentagem geral para os pontos.
        //Este valor será utilizado quando não existir "porcentagem de ponto" para determinado valor no cadastro de Faixa.
        [Required(ErrorMessage = "Preencha o campo % Geral de pontos")]
        public double? ValorPorcentagemGeralPontosFaixa { get; set; }

    }
}