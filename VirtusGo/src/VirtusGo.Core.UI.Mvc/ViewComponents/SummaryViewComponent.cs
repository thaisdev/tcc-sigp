using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtusGo.Core.Domain.Core.Notifications;

namespace VirtusGO.Core.UI.Mvc.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public SummaryViewComponent(IDomainNotificationHandler<DomainNotification> notification)
        {
            _notification = notification;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notification.GetNotifications());
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(String.Empty, c.Value));
            return View();
        }
    }
}