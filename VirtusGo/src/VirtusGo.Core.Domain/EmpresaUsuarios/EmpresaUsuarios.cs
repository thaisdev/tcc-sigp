using VirtusGo.Core.Domain.Core.Models;
using VirtusGo.Core.Domain.Empresa;

namespace VirtusGo.Core.Domain.EmpresaUsuarios
{
    public class EmpresaUsuarios : Entity<EmpresaUsuarios>
    {
        private EmpresaUsuarios(int id, int usuarioId, int empresaId)
        {
            Id = id;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }

        private EmpresaUsuarios()
        {
        }

        public int UsuarioId { get; private set; }

        public int EmpresaId { get; private set; }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }

        public static class EmpresaUsuariosFactory
        {
            public static EmpresaUsuarios EmpresaUsuariosCompleto(int id, int usuarioId, int empresaId)
            {
                var empresaUsuarios = new EmpresaUsuarios()
                {
                    Id = id,
                    UsuarioId = usuarioId,
                    EmpresaId = empresaId,
                };
                return empresaUsuarios;
            }
        }
    }
}