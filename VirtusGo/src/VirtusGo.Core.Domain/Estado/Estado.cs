using System.Collections.Generic;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.Estado
{
    public class Estado : Entity<Estado>
    {
        public Estado(int id, string nomeEstado, string siglaEstado)
        {
            Id = id;
            NomeEstado = nomeEstado;
            SiglaEstado = siglaEstado;
        }

        public Estado()
        {
        }

        public string NomeEstado { get; private set; }
        public string SiglaEstado { get; private set; }

        //EF Navigation
        public ICollection<Cidade.Cidade> Cidades { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarNomeEstado();
            ValidarSiglaEstado();
        }

        private void ValidarNomeEstado()
        {
            RuleFor(x => x.NomeEstado).NotEmpty().WithMessage("Nome do Estado não pode ser vazio").Length(2, 40)
                .WithMessage("Estado precisa ter de 2 a 40 caracteres");
        }

        private void ValidarSiglaEstado()
        {
            RuleFor(x => x.SiglaEstado).NotEmpty().WithMessage("Sigla do Estado não pode ser vazio").Length(2, 40)
                .WithMessage("Estado precisa ter de 2 a 40 caracteres");
        }

        #endregion

        public static class EstadoFactory
        {
            public static Estado EstadoCompleto(int id, string nomeEstado, string siglaEstado)
            {
                var estado = new Estado()
                {
                    Id = id,
                    NomeEstado = nomeEstado,
                    SiglaEstado = siglaEstado
                };
                return estado;
            }
        }
    }
}