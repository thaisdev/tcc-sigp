using System;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Empresa.Events
{
    public class BaseEmpresaEvent : Event
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string NumeroDocumento { get; set; }

        public FlagBloqueadoEnum Bloqueado { get; set; }

        public FlagExcluidoEnum Excluido { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Cep { get; set; }

        public string Bairro { get; set; }

        public string Endereco { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public string Contato { get; set; }

        public string Contato2 { get; set; }

        public string Ddd { get; set; }

        public string Telefone { get; set; }

        public string Ddd2 { get; set; }

        public string Telefone2 { get; set; }

        public string Ddd3 { get; set; }

        public string Telefone3 { get; set; }

        public int? QuantidadeFilial { get; set; }

        public int? DiasParaExpiracaoPontos { get; set; }

        public double? ValorComissãoGeral { get; set; }

        //Porcentagem geral para os pontos.
        //Este valor será utilizado quando não existir "porcentagem de ponto" para determinado valor no cadastro de Faixa.
        public double? PorcentagemPadraoPontos { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int UsuarioIdCriacao { get; set; }

        public int? UsuarioIdAlteracao { get; set; }
    }
}