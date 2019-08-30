using VirtusGo.Core.Domain.Core.Command;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Infra.Data.Context;

namespace VirtusGo.Core.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VirtusContext _context;

        public UnitOfWork(VirtusContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}