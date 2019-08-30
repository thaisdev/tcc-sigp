using System;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Empresa.Commands
{
    public class RegistrarEmpresaCommand : BaseEmpresaCommand
    {
        public RegistrarEmpresaCommand(string razaoSocial, string nomeFantasia, string numeroDocumento,
            FlagBloqueadoEnum bloqueado, FlagExcluidoEnum excluido, string email, string email2, string email3,
            string cep, string bairro, string endereco, string latitude, string longitude, string ramo,
            ProfissionalLiberal profissionalLiberal, PlanosParceiros plano, string uf, string cidade, string contato,
            string contato2,
            string ddd, string telefone, string ddd2, string telefone2, string ddd3, string telefone3,
            int? quantidadeFilial, int? diasParaExpiracaoPontos, double? valorComissãoGeral,
            double? porcentagemPadraoPontos, DateTime dataCriacao, DateTime? dataAlteracao, int usuarioIdCriacao,
            int? usuarioIdAlteracao)
        {
            Id = Id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            NumeroDocumento = numeroDocumento;
            Bloqueado = bloqueado;
            Excluido = excluido;
            Email = email;
            Email2 = email2;
            Email3 = email3;
            Cep = cep;
            Bairro = bairro;
            Endereco = endereco;
            Latitude = latitude;
            Longitude = longitude;
            Ramo = ramo;
            ProfissionalLiberal = profissionalLiberal;
            Plano = plano;
            Uf = uf;
            Cidade = cidade;
            Contato = contato;
            Contato2 = contato2;
            Ddd = ddd;
            Telefone = telefone;
            Ddd2 = ddd2;
            Telefone2 = telefone2;
            Ddd3 = ddd3;
            Telefone3 = telefone3;
            QuantidadeFilial = quantidadeFilial;
            DiasParaExpiracaoPontos = diasParaExpiracaoPontos;
            ValorComissãoGeral = valorComissãoGeral;
            PorcentagemPadraoPontos = porcentagemPadraoPontos;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
            UsuarioIdCriacao = usuarioIdCriacao;
            UsuarioIdAlteracao = usuarioIdAlteracao;

            AggregateId = Id;
        }
    }
}