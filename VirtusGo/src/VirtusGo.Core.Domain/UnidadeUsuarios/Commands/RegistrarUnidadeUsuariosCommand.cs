using System;
using System.Collections.Generic;
using System.Text;

namespace VirtusGo.Core.Domain.UnidadeUsuarios.Commands
{
    public class RegistrarUnidadeUsuariosCommand : BaseUnidadeUsuariosCommand
    {
        public RegistrarUnidadeUsuariosCommand(int id, int usuarioId, int unidadeId)
        {
            Id = id;
            UsuarioId = usuarioId;
            UnidadeId = unidadeId;
        }
    }
}
