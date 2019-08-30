using System;
using System.Collections.Generic;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Unidades;
using VirtusGo.Core.Domain.Validations.Documento;

namespace VirtusGo.Core.Domain.Empresa
{
    public class Empresas : Entity<Empresas>
    {
        public Empresas(int id, string razaoSocial, string nomeFantasia, string numeroDocumento,
            FlagBloqueadoEnum bloqueado, FlagExcluidoEnum excluido, string email, string email2, string email3,
            string cep, string bairro, string endereco, string latitude, string longitude, string ramo,
            ProfissionalLiberal profissionalLiberal, PlanosParceiros plano, string uf,
            string cidade, string contato, string contato2, string ddd, string telefone, string ddd2, string telefone2,
            string ddd3, string telefone3, int quantidadeFilial, int? diasParaExpiracaoPontos,
            double? valorComissãoGeral, double? porcentagemPadraoPontos, DateTime dataCriacao, DateTime? dataAlteracao,
            int usuarioIdCriacao, int? usuarioIdAlteracao)
        {
            Id = id;
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
        }

        private Empresas()
        {
        }

        public string RazaoSocial { get; private set; }

        public string NomeFantasia { get; private set; }

        public string NumeroDocumento { get; private set; }

        public FlagBloqueadoEnum Bloqueado { get; private set; }

        public FlagExcluidoEnum Excluido { get; private set; }

        public string Email { get; private set; }

        public string Email2 { get; private set; }

        public string Email3 { get; private set; }

        public string Cep { get; private set; }

        public string Bairro { get; private set; }

        public string Endereco { get; private set; }

        public string Latitude { get; private set; }

        public string Longitude { get; private set; }

        public string Ramo { get; private set; }

        public ProfissionalLiberal ProfissionalLiberal { get; set; }

        public PlanosParceiros Plano { get; set; }

        public string Uf { get; private set; }

        public string Cidade { get; private set; }

        public string Contato { get; private set; }

        public string Contato2 { get; private set; }

        public string Ddd { get; private set; }

        public string Telefone { get; private set; }

        public string Ddd2 { get; private set; }

        public string Telefone2 { get; private set; }

        public string Ddd3 { get; private set; }

        public string Telefone3 { get; private set; }

        public int? QuantidadeFilial { get; private set; }

        public int? DiasParaExpiracaoPontos { get; private set; }

        public double? ValorComissãoGeral { get; private set; }

        //Porcentagem geral para os pontos.
        //Este valor será utilizado quando não existir "porcentagem de ponto" para determinado valor no cadastro de Faixa.
        public double? PorcentagemPadraoPontos { get; private set; }

        public DateTime DataCriacao { get; private set; }

        public DateTime? DataAlteracao { get; private set; }

        public int UsuarioIdCriacao { get; private set; }

        public int? UsuarioIdAlteracao { get; private set; }

        //EF propriedade de navegação
        public virtual ICollection<Faixas.Faixa> Faixa { get; set; }
        public virtual ICollection<Unidade> Unidade { get; set; }
        public virtual ICollection<Pontuacao.Pontuacao> Pontuacao { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        public static class EmpresaFactory
        {
            public static Empresas EmpresaCompleta(int id, string razaoSocial, string nomeFantasia,
                string numeroDocumento,
                FlagBloqueadoEnum bloqueado, FlagExcluidoEnum excluido, string email, string email2, string email3,
                string cep, string bairro, string endereco, string latitude, string longitude, string ramo,
                ProfissionalLiberal profissionalLiberal, PlanosParceiros plano, string uf,
                string cidade, string contato, string contato2, string ddd, string telefone, string ddd2,
                string telefone2,
                string ddd3, string telefone3, int? quantidadeFilial, int? diasParaExpiracaoPontos,
                double? valorComissãoGeral, double? porcentagemPadraoPontos, DateTime dataCriacao,
                DateTime? dataAlteracao,
                int usuarioIdCriacao, int? usuarioIdAlteracao)
            {
                var empresa = new Empresas()
                {
                    Id = id,
                    RazaoSocial = razaoSocial,
                    NomeFantasia = nomeFantasia,
                    NumeroDocumento = numeroDocumento,
                    Bloqueado = bloqueado,
                    Excluido = excluido,
                    Email = email,
                    Email2 = email2,
                    Email3 = email3,
                    Cep = cep,
                    Bairro = bairro,
                    Endereco = endereco,
                    Latitude = latitude,
                    Longitude = longitude,
                    Ramo = ramo,
                    ProfissionalLiberal = profissionalLiberal,
                    Plano = plano,
                    Uf = uf,
                    Cidade = cidade,
                    Contato = contato,
                    Contato2 = contato2,
                    Ddd = ddd,
                    Telefone = telefone,
                    Ddd2 = ddd2,
                    Telefone2 = telefone2,
                    Ddd3 = ddd3,
                    Telefone3 = telefone3,
                    QuantidadeFilial = quantidadeFilial,
                    DiasParaExpiracaoPontos = diasParaExpiracaoPontos,
                    ValorComissãoGeral = valorComissãoGeral,
                    PorcentagemPadraoPontos = porcentagemPadraoPontos,
                    DataCriacao = dataCriacao,
                    DataAlteracao = dataAlteracao,
                    UsuarioIdCriacao = usuarioIdCriacao,
                    UsuarioIdAlteracao = usuarioIdAlteracao,
                };
                return empresa;
            }
        }


        #region Validações

        private void Validar()
        {
            ValidarTelefone();
            ValidarUF();
//            ValidarQtdFilial();
            ValidarNumeroDocumento();
            ValidarContato();
            ValidarCidade();
            ValidarEmail();
            ValidarEndereco();
            ValidarCep();
            ValidarBairro();
            ValidarRazaoSocial();
            ValidarNomeFantasia();

            ValidationResult = Validate(this);
        }

        private void ValidarRazaoSocial()
        {
            RuleFor(x => x.RazaoSocial)
                .NotEmpty().WithMessage("Razão social precisa ser fornecida")
                .Length(2, 100).WithMessage("Razão social precisa ter entre 2 e 100 caracteres");
        }

        private void ValidarNomeFantasia()
        {
            RuleFor(x => x.NomeFantasia)
                .NotEmpty().WithMessage("Nome fantasia precisa ser fornecido")
                .Length(2, 100).WithMessage("Nome fantasia precisa ter entre 2 e 100 caracteres");
        }

        private void ValidarNumeroDocumento()
        {
            RuleFor(x => x.NumeroDocumento)
                .NotEmpty().WithMessage("Número do documento precisa ser fornecido")
                .Length(18).WithMessage("Número documento precisa ter 19 caracteres");
        }

        private void ValidarEmail()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail precisa ser fornecido")
                .Length(2, 100).WithMessage("E-mail precisa ter entre 2 e 100 caracteres");
        }

        private void ValidarCep()
        {
            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("CEP precisa ser fornecido")
                .Length(9).WithMessage("CEP precisa ter 9");
        }

        private void ValidarBairro()
        {
            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("Bairro precisa ser fornecido")
                .Length(2, 60).WithMessage("Bairro precisa ter entre 2 e 60 caracteres");
        }

        private void ValidarEndereco()
        {
            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage("Endereço precisa ser fornecido")
                .Length(2, 60).WithMessage("Endereço precisa ter entre 2 60 caracteres");
        }

        private void ValidarCidade()
        {
            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("Cidade precisa ser fornecida")
                .Length(2, 60).WithMessage("Cidade precisa ter 2 e 60 caracteres");
        }

        private void ValidarUF()
        {
            RuleFor(x => x.Uf)
                .NotEmpty().WithMessage("UF precisa ser fornecido")
                .Length(2).WithMessage("UF precisa ter 2 caracteres");
        }

        private void ValidarContato()
        {
            RuleFor(x => x.Contato)
                .NotEmpty().WithMessage("Contato precisa ser fornecido")
                .Length(2, 50).WithMessage("Contato precisa ter entre 2 e 50 caracteres");
        }

        private void ValidarTelefone()
        {
            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("telefone precisa ser fornecido")
                .MaximumLength(10).WithMessage("Telefone precisa ter no máximo 10 caracteres");
        }

        private void ValidarQtdFilial()
        {
            RuleFor(x => x.QuantidadeFilial)
                .NotEmpty().WithMessage("Quantidade de filial precisa ser fornecida");
        }

        private void ValidarComissao()
        {
            RuleFor(x => x.ValorComissãoGeral)
                .NotEmpty().WithMessage("Valor da comissão precisa ser fornecido");
        }

        private void ValidarPorcentagemPadraoPontos()
        {
            RuleFor(x => x.PorcentagemPadraoPontos)
                .NotEmpty().WithMessage("Porcentagem Padrao de Pontos precisa ser fornecida");
        }

        #endregion
    }
}