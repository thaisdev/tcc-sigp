using System.Collections.Generic;
using VirtusGo.Core.Domain.Core.Events;

namespace VirtusGo.Core.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}