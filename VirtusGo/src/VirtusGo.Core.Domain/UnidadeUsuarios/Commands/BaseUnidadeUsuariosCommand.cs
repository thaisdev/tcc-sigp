using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.UnidadeUsuarios.Commands
{
    public class BaseUnidadeUsuariosCommand : Command
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int UnidadeId { get; set; }

    }
}
