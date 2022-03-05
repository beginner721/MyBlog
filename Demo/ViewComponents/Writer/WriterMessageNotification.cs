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
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IViewComponentResult Invoke()
        {
            string test = "baran@gmail.com";
            var values = messageManager.GetAllInboxByWriter(test); 
            return View(values);
        }
    }
}
