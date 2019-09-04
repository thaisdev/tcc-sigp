using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Application.ViewModels
{
    public class ListarUnidadeViewModel
    {
        public int Id { get; set; }

        public string RazaoSocial { get; set; }

        public string Fantasia { get; set; }

        public string Documento { get; set; }

        public string Email { get; set; }

        public string Ddd { get; set; }

        public string Telefone { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Endereco { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Ramo { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public FlagBloqueadoEnum FlagBloqueado { get; set; }

        public FlagExcluidoEnum FlagExcluido { get; set; }

        public int UsuarioIdCriador { get; set; }

        public int? UsuarioIdAltera { get; set; }

        //public virtual Usuario Usuario { get; set; }

        public int EmpresaId { get; set; }

        public string Empresa { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int? NumeroDiasParaExpiracaoPontos { get; set; }
        public double? ComissaoGeral { get; set; }
        public double? ValorPorcentagemGeralPontos { get; set; }
    }
}