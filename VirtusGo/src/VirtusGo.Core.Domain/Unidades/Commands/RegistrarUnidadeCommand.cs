using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Unidades.Commands
{
    public class RegistrarUnidadeCommand : BaseUnidadeCommand
    {
        public RegistrarUnidadeCommand(string razaoSocial, string fantasia, string documento, string email, string ddd,
            string telefone, string cep, string bairro, string endereco, string latitude, string longitude, string ramo,
            string uf, string cidade,
            FlagBloqueadoEnum flagBloqueado, FlagExcluidoEnum flagExcluido, int usuarioIdCriador, int? usuarioIdAltera,
            int empresaId, DateTime dataCriacao, DateTime? dataAlteracao, int? numeroDiasParaExpiracaoPontos,
            double? comissaoGeral, double? valorPorcentagemGeralPontos)
        {
            Id = Id;
            RazaoSocial = razaoSocial;
            Fantasia = fantasia;
            Documento = documento;
            Email = email;
            Ddd = ddd;
            Telefone = telefone;
            Cep = cep;
            Bairro = bairro;
            Endereco = endereco;
            Latitude = latitude;
            Longitude = longitude;
            Ramo = ramo;
            Uf = uf;
            Cidade = cidade;
            FlagBloqueado = flagBloqueado;
            FlagExcluido = flagExcluido;
            UsuarioIdCriador = usuarioIdCriador;
            UsuarioIdAltera = usuarioIdAltera;
            EmpresaId = empresaId;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            NumeroDiasParaExpiracaoPontos = numeroDiasParaExpiracaoPontos;
            ComissaoGeral = comissaoGeral;
            ValorPorcentagemGeralPontos = valorPorcentagemGeralPontos;

            AggregateId = Id;
        }
    }
}