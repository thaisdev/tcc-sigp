using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.UnidadeUsuarios;
using VirtusGo.Core.Domain.UnidadeUsuarios.Repository;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.Repository
{
    public class UnidadeUsuarioRepository : Repository<UnidadeUsuarios>, IUnidadeUsuarioRepository
    {
        public UnidadeUsuarioRepository(VirtusContext context) : base(context)
        {
        }
    }
}
