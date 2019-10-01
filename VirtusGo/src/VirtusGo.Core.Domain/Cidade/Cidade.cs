using System.Collections.Generic;
using FluentValidation;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.Cidade
{
    public class Cidade : Entity<Cidade>
    {
        public Cidade(int id, string nomeCidade, int estadoId)
        {
            Id = id;
            NomeCidade = nomeCidade;
            EstadoId = estadoId;
        }

        private Cidade()
        {
        }

        public string NomeCidade { get; private set; }
        public int EstadoId { get; private set; }

        //EF Navigation
        public ICollection<Endereco.Endereco> Endereco { get; set; }
        public Estado.Estado Estado { get; set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarNomeCidade();
            ValidationResult = Validate(this);
        }

        private void ValidarNomeCidade()
        {
            RuleFor(x => x.NomeCidade).NotEmpty().WithMessage("Nome da Cidade não pode ser vazio").Length(2, 40)
                .WithMessage("Cidade precisa ter de 2 a 40 caracteres");
        }

        #endregion

        public static class CidadeFactory
        {
            public static Cidade CidadeCompleto(int id, string nomeCidade, int estadoId)
            {
                var cidade = new Cidade()
                {
                    Id = id,
                    NomeCidade = nomeCidade,
                    EstadoId = estadoId,
                };
                return cidade;
            }
        }
    }
}