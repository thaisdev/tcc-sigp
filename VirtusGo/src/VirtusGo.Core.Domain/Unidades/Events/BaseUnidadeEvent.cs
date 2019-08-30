using System;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Unidades.Events
{
    public class BaseUnidadeEvent : Event
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

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public FlagBloqueadoEnum FlagBloqueado { get; set; }

        public FlagExcluidoEnum FlagExcluido { get; set; }

        public int UsuarioIdCriador { get; set; }

        public int? UsuarioIdAltera { get; set; }

        public int EmpresaId { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int? NumeroDiasParaExpiracaoPontos { get; set; }

        public double? ComissaoGeral { get; set; }
        public double? ValorPorcentagemGeralPontos { get; set; }
        //public virtual Usuarios Usuario { get; set; }
        public virtual Empresas Empresa { get; set; }
    }
}