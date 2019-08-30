namespace VirtusGo.Core.Domain.EmpresaUsuarios.Command
{
    public class RegistrarEmpresaUsuariosCommand : BaseEmpresaUsuariosCommand
    {
        public RegistrarEmpresaUsuariosCommand(int id, int usuarioId, int empresaId)
        {
            Id = id;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }
    }
}