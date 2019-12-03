using System;
using System.Collections.Generic;
using System.Text;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.Domain.Motoristas.Repository
{
    public interface IMotoristaRepository : IRepository<Motorista>
    {
        IEnumerable<Motorista> ObterTodosQueriable();
    }
}
