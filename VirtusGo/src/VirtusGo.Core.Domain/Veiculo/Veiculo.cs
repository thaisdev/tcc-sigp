using System.Collections.Generic;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.Veiculo
{
    public class Veiculo : Entity<Veiculo>
    {
        public Veiculo(int id, string placa, string modelo, string cor, string marca, string renavam, int parceiroId)
        {
            Id = id;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            Marca = marca;
            Renavam = renavam;
            ParceiroId = parceiroId;
        }

        private Veiculo()
        {
        }

        public string Placa { get; private set; }
        public string Modelo { get; private set; }
        public string Cor { get; private set; }
        public string Marca { get; private set; }
        public string Renavam { get; private set; }
        public int ParceiroId { get; set; }

        //EF Navigation
        public Parceiro.Parceiro Parceiro { get; set; }
        public ICollection<OrdemCarga.OrdemCarga> OrdemCarga { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarPlaca();
            ValidarModelo();
            ValidarCor();
            ValidarMarca();
            ValidarRenavam();
        }

        private void ValidarPlaca()
        {
            RuleFor(x => x.Placa).NotEmpty().WithMessage("Placa é obrigatório").Length(8, 8)
                .WithMessage("Placa não pode ter menos ou mais que 8 caracteres");
        }

        private void ValidarModelo()
        {
            RuleFor(x => x.Modelo).NotEmpty().WithMessage("Modelo é obrigatório").Length(2, 20)
                .WithMessage("Modelo deve ter entre 2 e 20 caracteres");
        }

        private void ValidarCor()
        {
            RuleFor(x => x.Cor).NotEmpty().WithMessage("Cor é obrigatório").Length(2, 20)
                .WithMessage("Cor deve ter entre 2 e 20 caracteres");
        }

        private void ValidarMarca()
        {
            RuleFor(x => x.Marca).NotEmpty().WithMessage("Marca é obrigatório").Length(2, 20)
                .WithMessage("Marca deve ter entre 2 e 20 caracteres");
        }

        private void ValidarRenavam()
        {
            RuleFor(x => x.Renavam).NotEmpty().WithMessage("Renavam é obrigatório").Length(2, 20)
                .WithMessage("Renavam deve ter entre 2 e 20 caracteres");
        }

        #endregion

        public static class VeiculoFactory
        {
            public static Veiculo VeiculoCompleto(int id, string placa, string modelo, string cor, string marca,
                string renavam, int parceiroId)
            {
                var veiculo = new Veiculo()
                {
                    Id = id,
                    Placa = placa,
                    Modelo = modelo,
                    Cor = cor,
                    Marca = marca,
                    Renavam = renavam,
                    ParceiroId = parceiroId
                };
                return veiculo;
            }
        }
    }
}