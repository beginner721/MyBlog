using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Dal());
        public IViewComponentResult Invoke()
        {
            int id = 1;
            var values = messageManager.GetAllInboxByWriter(id); 
            return View(values);
        }
    }
}
