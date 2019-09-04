using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Beneficiarios
{
    public class Beneficiario : Entity<Beneficiario>
    {
        public Beneficiario(
            int id,
            string nome,
            TipoPessoaEnum tipPessoa, string numeroDocumento,
            string ddd, string telefone,
            string email, string cep,
            string bairro, string endereco,
            string uf, string cidade,
            FlagExcluidoEnum excluido, int usuarioCriacaoId,
            int? usuarioAlteracaoId, DateTime dataCadastro,
            DateTime? dataAlteracao)
        {
            Id = id;
            Nome = nome;
            TipPessoa = tipPessoa;
            NumeroDocumento = numeroDocumento;
            Ddd = ddd;
            Telefone = telefone;
            Email = email;
            Cep = cep;
            Bairro = bairro;
            Endereco = endereco;
            Uf = uf;
            Cidade = cidade;
            Excluido = excluido;
            UsuarioCriacaoId = usuarioCriacaoId;
            UsuarioAlteracaoId = usuarioAlteracaoId;
            DataCadastro = dataCadastro;
            DataAlteracao = dataAlteracao;
        }

        private Beneficiario() { }


        public string Nome { get; private set; }

        public TipoPessoaEnum TipPessoa { get; private set; }

        public string NumeroDocumento { get; private set; }

        public string Ddd { get; private set; }

        public string Telefone { get; private set; }

        public string Email { get; private set; }

        public string Cep { get; private set; }

        public string Bairro { get; private set; }

        public string Endereco { get; private set; }


        public string Uf { get; private set; }


        public string Cidade { get; private set; }


        public FlagExcluidoEnum Excluido { get; private set; }

        public int UsuarioCriacaoId { get; private set; }

        public int? UsuarioAlteracaoId { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public DateTime? DataAlteracao { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        //EF de navegacao
//        public virtual ICollection<Pontuacao.Pontuacao> Pontuacao { get; set; }


        #region Validações

        private void Validar()
        {
            ValidarNome();
            ValidarDocumento();
            ValidarBairro();
            ValidarCep();
            ValidarCidade();
            ValidarEmail();
            ValidarTelefone();
            ValidarDataCadastro();
            ValidarEndereco();

            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do beneficiario precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do beneficiario precisa ter entre 2 e 150 caracteres");
        }

        private void ValidarDocumento()
        {
            RuleFor(c => c.NumeroDocumento)
                .NotEmpty().WithMessage("Número do documento precisa ser fornecido")
                .Length(14).WithMessage("Número do documento precisa ter 14 caracteres");
        }

        private void ValidarTelefone()
        {
            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Telefone precisa ser fornecido")
                .MaximumLength(10).WithMessage("Telefone precisa ter no máximo 10 caracteres");
        }

        private void ValidarEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email precisa ser fornecido")
                .Length(2, 60).WithMessage("Email precisa ter entre 2 e 60 caracteres");
        }

        private void ValidarCep()
        {
            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("CEP precisa ser fornecido")
                .Length(9).WithMessage("CEP precisa ter 9 caracteres");
        }

        private void ValidarBairro()
        {
            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("Bairro precisa ser fornecido")
                .Length(2, 60).WithMessage("Bairro precisa ter entre 2 e 60 caracteres");
        }

        private void ValidarEndereco()
        {
            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("Endereço precisa ser fornecido")
                .Length(2, 60).WithMessage("Endereço precisa ter entre 2 e 60 caracteres");
        }

        private void ValidarCidade()
        {
            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Cidade precisa ser fornecida")
                .Length(2, 60).WithMessage("Cidade precisa ter entre 2 e 60 caracteres");
        }

        private void ValidarDataCadastro()
        {
            RuleFor(c => c.DataCadastro)
                .NotEmpty().WithMessage("Data de cadastro precisa ser fornecido");
        }

        #endregion

        public static class BeneficiarioFactory
        {
            public static Beneficiario BeneficiarioCompleto(int id, string nome, TipoPessoaEnum tipPessoa,
                string numeroDocumento, string ddd, string telefone, string email, string cep, string bairro,
                string endereco, string uf, string cidade, FlagExcluidoEnum excluido, int usuarioCriacaoId,
                int? usuarioAlteracaoId, DateTime dataCadastro, DateTime? dataAlteracao)
            {
                var beneficiario = new Beneficiario()
                {
                    Id = id,
                    Nome = nome,
                    TipPessoa = tipPessoa,
                    NumeroDocumento = numeroDocumento,
                    Ddd = ddd,
                    Telefone = telefone,
                    Email = email,
                    Cep = cep,
                    Bairro = bairro,
                    Endereco = endereco,
                    Uf = uf,
                    Cidade = cidade,
                    Excluido = excluido,
                    UsuarioCriacaoId = usuarioCriacaoId,
                    UsuarioAlteracaoId = usuarioAlteracaoId,
                    DataCadastro = dataCadastro,
                    DataAlteracao = dataAlteracao
                };

                return beneficiario;
            }
        }
    }
}