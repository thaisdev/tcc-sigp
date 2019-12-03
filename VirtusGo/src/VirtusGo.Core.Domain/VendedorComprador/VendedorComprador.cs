using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Enums;

namespace VirtusGo.Core.Domain.VendedorComprador
{
    public class VendedorComprador : Entity<VendedorComprador>
    {
        public VendedorComprador(
            int id,
            string nome,
            FlagCompradorVendedorEnum vendedor,
            FlagCompradorVendedorEnum comprador,
            double comissao
            )
        {
            Id = id;
            Nome = nome;
            Vendedor = vendedor;
            Comprador = comprador;
            Comissao = comissao;
        }
        private VendedorComprador() { }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public FlagCompradorVendedorEnum Vendedor { get; private set; }
        public FlagCompradorVendedorEnum Comprador { get; private set; }
        public double Comissao { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarNome();
            ValidarComissao();
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome é obrigatóirio")
                .Length(2, 40).WithMessage("É necessário pelo menos 2 carácteres");
        }
        private void ValidarComissao()
        {
            RuleFor(c => c.Comissao)
                .NotEmpty().WithMessage("A comissão é obrigatóiria");
        }
        #endregion

        public static class VendedorCompradorFactory
        {
            public static VendedorComprador VendedorCompradorCompleto(int id, string nome,
                FlagCompradorVendedorEnum vendedor, FlagCompradorVendedorEnum comprador, double comissao)
            {
                var vendedorComprador = new VendedorComprador()
                {
                    Id = id,
                    Nome = nome,
                    Vendedor = vendedor,
                    Comprador = comprador,
                    Comissao = comissao,
                };
                return vendedorComprador;
            }
        }
    }
}
