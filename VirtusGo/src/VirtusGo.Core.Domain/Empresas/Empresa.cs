using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.Empresa
{
    public class Empresa : Entity<Empresa>
    {
        public Empresa(
            int id,
            string razao,
            string cnpj,
            string inscri,
            int enderecoId
        )
        {
            Id = id;
            Razao = razao;
            CNPJ = cnpj;
            Inscri = inscri;
            EnderecoId = enderecoId;
        }

        private Empresa()
        {
        }

        public string Razao { get; private set; }
        public string CNPJ { get; private set; }
        public string Inscri { get; private set; }
        public int EnderecoId { get; private set; }

        //EF Navigation
        public Endereco.Endereco Endereco { get; set; }
        public ICollection<Pedido.Pedido> Pedidos { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarRazao();
            ValidarCNPJ();
            ValidarInscri();

            ValidationResult = Validate(this);
        }

        private void ValidarRazao()
        {
            RuleFor(c => c.Razao)
                .NotEmpty().WithMessage("A razão social é obrigatóiria")
                .Length(2, 40).WithMessage("É necessário pelo menos 2 carácteres");
        }

        private void ValidarCNPJ()
        {
            RuleFor(c => c.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatóirio")
                .Length(14).WithMessage("É necessário 14 carácteres");
        }

        private void ValidarInscri()
        {
            RuleFor(c => c.Inscri)
                .NotEmpty().WithMessage("A Inscrição nacional é obrigatóiria")
                .Length(2, 12).WithMessage("É necessário pelo menos de 2 a 12 carácteres");
        }

        #endregion

        public static class EmpresaFactory
        {
            public static Empresa EmpresaCompleto(int id, string razao, string cnpj, string inscri, int enderecoId)
            {
                var empresa = new Empresa()
                {
                    Id = id,
                    Razao = razao,
                    CNPJ = cnpj,
                    Inscri = inscri,
                    EnderecoId = enderecoId,
                };
                return empresa;
            }
        }
    }
}