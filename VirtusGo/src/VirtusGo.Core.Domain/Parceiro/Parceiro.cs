using System.Collections.Generic;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.Parceiro
{
    public class Parceiro : Entity<Parceiro>
    {
        public Parceiro(int id, string nome, string numeroDocumento, int enderecoId, string email,
            TipoPessoaEnum tipoPessoa, string rgInscricaoEstadual, string site, string telefone)
        {
            Id = id;
            Nome = nome;
            NumeroDocumento = numeroDocumento;
            EnderecoId = enderecoId;
            Email = email;
            TipoPessoa = tipoPessoa;
            RgInscricaoEstadual = rgInscricaoEstadual;
            Site = site;
            Telefone = telefone;
        }

        private Parceiro()
        {
        }

        public string Nome { get; private set; }
        public string NumeroDocumento { get; private set; }
        public int EnderecoId { get; private set; }
        public string Email { get; private set; }
        public TipoPessoaEnum TipoPessoa { get; private set; }
        public string RgInscricaoEstadual { get; private set; }
        public string Site { get; private set; }
        public string Telefone { get; private set; }


        //EF Navigation
        public Endereco.Endereco Endereco { get; set; }
        public ICollection<Veiculo.Veiculo> Veiculos { get; set; }

        public ICollection<Pedido.Pedido> Pedidos { get; set; }
        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region validacoes

        private void Validar()
        {
            ValidarNome();
            ValidarEmail();
            ValidarTelefone();
            ValidarNumeroDocumento();
            ValidarRgInscricaoEstadual();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome precisa ser informado.").Length(2, 40)
                .WithMessage("Nome precisa ter entre 2 e 40 caracteres");
        }

        private void ValidarNumeroDocumento()
        {
            RuleFor(x => x.NumeroDocumento).NotEmpty().WithMessage("Numero do documento precisa ser informado.")
                .Length(14)
                .WithMessage("Nome precisa ter 14 caracteres");
        }

        private void ValidarEmail()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email precisa ser informado.")
                .Length(2, 40)
                .WithMessage("Email precisa ter entre 2 e 40 caracteres");
        }

        private void ValidarRgInscricaoEstadual()
        {
            RuleFor(x => x.RgInscricaoEstadual).NotEmpty()
                .WithMessage("RG ou Inscricao Estadual precisa ser informado.")
                .Length(12)
                .WithMessage("Email precisa ter 12 caracteres");
        }

        private void ValidarTelefone()
        {
            RuleFor(x => x.RgInscricaoEstadual).NotEmpty()
                .WithMessage("Telefone precisa ser informado.");
        }

        #endregion

        public static class ParceiroFactory
        {
            public static Parceiro ParceiroCompleto(int id, string nome, string numeroDocumento, int enderecoId,
                string email,
                TipoPessoaEnum tipoPessoa, string rgInscricaoEstadual, string site, string telefone)
            {
                var parceiro = new Parceiro()
                {
                    Id = id,
                    Nome = nome,
                    NumeroDocumento = numeroDocumento,
                    EnderecoId = enderecoId,
                    Email = email,
                    TipoPessoa = tipoPessoa,
                    RgInscricaoEstadual = rgInscricaoEstadual,
                    Site = site,
                    Telefone = telefone
                };

                return parceiro;
            }
        }
    }
}