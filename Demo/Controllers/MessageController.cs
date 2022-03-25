using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Dal());
        public IActionResult InBox()
        {
            int id = 1;
            var values = messageManager.GetMessageListByWriter(id);
            return View(values);
        }

        public IActionResult Details(int id)
        {
            var value= messageManager.GetById(id);
            return View(value);
        }
    }
}
