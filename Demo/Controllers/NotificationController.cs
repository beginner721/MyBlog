using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Demo.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AllNotification()
        {
            var values=notificationManager.GetAll();
            foreach (var notification in values)
            {
                var currentDate = notification.Date;
                var calculatedDate=TimeAgoHelper.GetTimeSince(currentDate);
                ViewData[$"{notification.Id}"]=calculatedDate;
            }
            return View(values);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult TestAddNotification(string details)
        {
            Notification notification1 = new Notification();
            notification1.Status = true;
            notification1.Type = "test";
            notification1.Details = details;
            notification1.Date = System.DateTime.Now;

            notificationManager.Add(notification1);


            return RedirectToAction("AllNotification","Notification");
        }
    }
}
