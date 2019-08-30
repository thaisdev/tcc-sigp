using System;
using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.Core.Command
{
    public class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}