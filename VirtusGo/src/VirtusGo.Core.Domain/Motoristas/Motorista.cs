using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.Motoristas
{
    public class Motorista : Entity<Motorista>
    {
        public Motorista(
            int id,
            string nome,
            string cpf,
            string categoriaCnh,
            string numeroCnh,
            string telefone,
            DateTime dataNascimento,
            DateTime dataVencimentoCnh,
            int enderecoId)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            CategoriaCNH = categoriaCnh;
            NumeroCNH = numeroCnh;
            Telefone = telefone;
            DataNascimento = dataNascimento;
            DataVencimentoCNH = dataVencimentoCnh;
            EnderecoId = enderecoId;
        }

        private Motorista() { }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string CategoriaCNH { get; private set; }
        public string NumeroCNH { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataVencimentoCNH { get; private set; }
        public int EnderecoId { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarCPF();
            ValidarNome();
            ValidaCategoriaCnh();
            ValidarNumeroCNH();
            ValidarTelefone();
            ValidarDataNascimento();
            ValidarDataVencimentoCNH();

            ValidationResult = Validate(this);
        }
        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome obrigatório")
                .Length(2, 20).WithMessage("É necessário ter de 2 a 20 carácteres");
        }

        private void ValidarCPF()
        {
            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório")
                .Length(2, 20).WithMessage("É necessário ter de 2 a 20 carácteres");
        }
        private void ValidaCategoriaCnh()
        {
            RuleFor(c => c.CategoriaCNH)
                .NotEmpty().WithMessage("A CNH é obrigatória")
                .Length(2, 20).WithMessage("É necessário ter de 2 a 20 carácteres");
        }
        private void ValidarNumeroCNH()
        {
            RuleFor(c => c.NumeroCNH)
                .NotEmpty().WithMessage("O número da CNH é obrigatório")
                .Length(2, 20).WithMessage("É necessário ter de 2 a 20 carácteres");
        }
        private void ValidarTelefone()
        {
            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório")
                .Length(2, 20).WithMessage("É necessário ter de 2 a 20 carácteres");
        }
        private void ValidarDataNascimento()
        {
            RuleFor(c => c.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória");
        }
        private void ValidarDataVencimentoCNH()
        {
            RuleFor(c => c.DataVencimentoCNH)
                .NotEmpty().WithMessage("A data de vencimento da CNH é obrigatória");
        }
        #endregion

        public static class MotoristaFactory
        {
            public static Motorista MotoristaCompleto(
            int id,
            string nome,
            string cpf,
            string categoriaCnh,
            string numeroCnh,
            string telefone,
            DateTime dataNascimento,
            DateTime dataVencimentoCnh,
            int enderecoId)
            {
                var motorista = new Motorista()
                {
                    Id = id,
                    Nome = nome,
                    CPF = cpf,
                    CategoriaCNH = categoriaCnh,
                    NumeroCNH = numeroCnh,
                    Telefone = telefone,
                    DataNascimento = dataNascimento,
                    DataVencimentoCNH = dataVencimentoCnh,
                    EnderecoId = enderecoId,
                };

                return motorista;
            }
        }

    }
}


