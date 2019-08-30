using System;
using System.Collections.Generic;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Enums;
using VirtusGo.Core.Domain.Faixas;
using VirtusGo.Core.Domain.PontuacaoPdv;

namespace VirtusGo.Core.Domain.Unidades
{
    public class Unidade : Entity<Unidade>
    {
        public Unidade(int id, string razaoSocial, string fantasia, string documento, string email, string ddd,
            string telefone, string cep, string bairro, string endereco, string latitude, string longitude, string ramo,
            string uf, string cidade,
            FlagBloqueadoEnum flagBloqueado, FlagExcluidoEnum flagExcluido, int usuarioIdCriador, int? usuarioIdAltera,
            int empresaId, DateTime dataCriacao, DateTime? dataAlteracao, int? numeroDiasParaExpiracaoPontos,
            double? comissaoGeral, double? valorPorcentagemGeralPontos)
        {
            Id = id;
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
        }

        private Unidade()
        {
        }

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

        public int EmpresaId { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public int? NumeroDiasParaExpiracaoPontos { get; set; }

        public double? ComissaoGeral { get; set; }
        public double? ValorPorcentagemGeralPontos { get; set; }

        //EF propriedade de navegação
        //public virtual Usuarios Usuario { get; set; }
        public virtual Empresas Empresa { get; set; }
        public virtual ICollection<PontuacaoPDV> PontuacaoPdv { get; set; }
        public virtual ICollection<Faixa> Faixa { get; set; }
        public virtual ICollection<Pontuacao.Pontuacao> Pontuacao { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        public static class UnidadeFactory
        {
            public static Unidade UnidadeCompleta(int id, string razaoSocial, string fantasia, string documento,
                string email, string ddd, string telefone, string cep, string bairro, string endereco, string latitude,
                string longitude, string ramo, string uf,
                string cidade, FlagBloqueadoEnum flagBloqueado, FlagExcluidoEnum flagExcluido, int usuarioIdCriador,
                int? usuarioIdAltera, int empresaId, DateTime dataCriacao, DateTime? dataAlteracao,
                int? numeroDiasParaExpiracaoPontos, double? comissaoGeral, double? valorPorcentagemGeralPontos)
            {
                var unidade = new Unidade()
                {
                    Id = id,
                    RazaoSocial = razaoSocial,
                    Fantasia = fantasia,
                    Documento = documento,
                    Email = email,
                    Ddd = ddd,
                    Telefone = telefone,
                    Cep = cep,
                    Bairro = bairro,
                    Endereco = endereco,
                    Latitude = latitude,
                    Longitude = longitude,
                    Ramo = ramo,
                    Uf = uf,
                    Cidade = cidade,
                    FlagBloqueado = flagBloqueado,
                    FlagExcluido = flagExcluido,
                    UsuarioIdCriador = usuarioIdCriador,
                    UsuarioIdAltera = usuarioIdAltera,
                    EmpresaId = empresaId,
                    DataCriacao = dataCriacao,
                    DataAlteracao = dataAlteracao,
                    NumeroDiasParaExpiracaoPontos = numeroDiasParaExpiracaoPontos,
                    ComissaoGeral = comissaoGeral,
                    ValorPorcentagemGeralPontos = valorPorcentagemGeralPontos
                };
                return unidade;
            }
        }

        #region Validações

        private void Validar()
        {
            ValidarCidade();
            ValidarEmail();
            ValidarEndereco();
            ValidarCep();
            ValidarBairro();
            ValidarRazaoSocial();
            ValidarNomeFantasia();
            ValidarNumeroDocumento();
            ValidarTelefone();
            ValidarUf();
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
            RuleFor(x => x.Fantasia)
                .NotEmpty().WithMessage("Nome fantasia precisa ser fornecido")
                .Length(2, 100).WithMessage("Nome fantasia precisa ter entre 2 e 100 caracteres");
        }

        private void ValidarNumeroDocumento()
        {
            RuleFor(x => x.Documento)
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

        private void ValidarUf()
        {
            RuleFor(x => x.Uf)
                .NotEmpty().WithMessage("UF precisa ser fornecido")
                .Length(2).WithMessage("UF precisa ter 2 caracteres");
        }

        private void ValidarTelefone()
        {
            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("telefone precisa ser fornecido")
                .MaximumLength(10).WithMessage("Telefone precisa ter no máximo 10 caracteres");
        }

        private void ValidarComissao()
        {
            RuleFor(x => x.ComissaoGeral)
                .NotEmpty().WithMessage("Valor da comissão precisa ser fornecido");
        }

        private void ValidarPorcentagemPadraoPontos()
        {
            RuleFor(x => x.ValorPorcentagemGeralPontos)
                .NotEmpty().WithMessage("Porcentagem Padrao de Pontos precisa ser fornecida");
        }

        #endregion
    }
}