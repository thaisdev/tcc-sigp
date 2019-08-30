using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : VirtusGo.Core.Domain.Core.Command.Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}