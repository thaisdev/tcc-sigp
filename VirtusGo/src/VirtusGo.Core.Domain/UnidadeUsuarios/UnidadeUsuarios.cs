using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Models;

namespace VirtusGo.Core.Domain.UnidadeUsuarios
{
    public class UnidadeUsuarios : Entity<UnidadeUsuarios>
    {
        private UnidadeUsuarios(int id, int usuarioId, int unidadeId)
        {
            Id = id;
            UsuarioId = usuarioId;
            UnidadeId = unidadeId;
        }

        private UnidadeUsuarios()
        {
        }

        public int UsuarioId { get; set; }
        public int UnidadeId { get; set; }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }

        public static class UnidadeUsuariosFactory
        {
            public static UnidadeUsuarios UnidadeUsuariosCompleto(int id, int usuarioId, int unidadeId)
            {
                var unidadeUsuarios = new UnidadeUsuarios()
                {
                    Id = id,
                    UsuarioId = usuarioId,
                    UnidadeId = unidadeId,
                };

                return unidadeUsuarios;
            }
        }
    }
}
