using System;
using VirtusGo.Core.Domain.Core.Command;

namespace VirtusGo.Core.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}