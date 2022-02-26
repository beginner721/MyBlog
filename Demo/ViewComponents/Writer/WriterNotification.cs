using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new EfNotificationDal());
        public IViewComponentResult Invoke()
        {
            var values = notificationManager.GetAll();
            return View(values);
        }
    }
}
