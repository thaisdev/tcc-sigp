using VirtusGo.Core.Domain.Empresa;

namespace VirtusGo.Core.Domain.EmpresaUsuarios.Command
{
    public class BaseEmpresaUsuariosCommand : Core.Command.Command
    {
        public int Id { get; set; }
        
        public int UsuarioId { get; set; }

        public int EmpresaId { get; set; }
    }
}