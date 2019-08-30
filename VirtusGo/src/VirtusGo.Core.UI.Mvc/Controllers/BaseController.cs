using System;
using Microsoft.AspNetCore.Mvc;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Interfaces;

namespace VirtusGo.Core.UI.Mvc.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notification;
        private readonly IUser _user;

        public BaseController(IDomainNotificationHandler<DomainNotification> notification, IUser user)
        {
            _notification = notification;
            _user = user;

            if (_user.IsAuthenticated())
            {
                UserId = _user.GetUserId();
            }
        }

        public int UserId { get; set; }

        protected bool OperacaoValida()
        {
            return (!_notification.HasNotifications());
        }
    }
}