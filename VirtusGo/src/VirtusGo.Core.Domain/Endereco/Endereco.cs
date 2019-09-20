using System.Collections.Generic;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.Endereco
{
    public class Endereco : Entity<Endereco>
    {
        public Endereco(int id, string logradouro, string numero, string bairro, int cidadeId, string cep)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CidadeId = cidadeId;
            Cep = cep;
        }

        private Endereco()
        {
        }


        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public int CidadeId { get; private set; }
        public string Cep { get; private set; }

        //EF navigation
        public Rota.Rota Rota { get; set; }
        public ICollection<Parceiro.Parceiro> Parceiro { get; set; }


        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validacoes

        private void Validar()
        {
            ValidarLogradouro();
            ValidarBairro();
            ValidarCep();
            ValidarNumero();
            ValidationResult = Validate(this);
        }

        private void ValidarLogradouro()
        {
            RuleFor(x => x.Logradouro).NotEmpty().WithMessage("Logradouro nao pode ser vazio.").Length(2, 40)
                .WithMessage("Logradouro precisa ter de 2 a 40 caracteres");
        }

        private void ValidarNumero()
        {
            RuleFor(x => x.Numero).NotEmpty().WithMessage("Numero nao pode ser vazio.").Length(1, 10)
                .WithMessage("Numero precisa ter de 1 a 10 caracteres");
        }

        private void ValidarBairro()
        {
            RuleFor(x => x.Bairro).NotEmpty().WithMessage("Bairro nao pode ser vazio.").Length(2, 20)
                .WithMessage("Bairro precisa ter de 2 a 40 caracteres");
        }

        private void ValidarCep()
        {
            RuleFor(x => x.Cep).NotEmpty().WithMessage("CEP nao pode ser vazio.").MaximumLength(40)
                .WithMessage("Quantidade maxima de caracteres e de 40.");
        }

        #endregion

        public static class EnderecoFactory
        {
            public static Endereco EnderecoCompleto(int id, string logradouro, string numero, string bairro,
                int cidadeId, string cep)
            {
                var endereco = new Endereco()
                {
                    Id = id,
                    Logradouro = logradouro,
                    Numero = numero,
                    Bairro = bairro,
                    CidadeId = cidadeId,
                    Cep = cep
                };

                return endereco;
            }
        }
    }
}