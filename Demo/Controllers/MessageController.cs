using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Dal());
        UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult InBox()
        {
            var userIdentity = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var values = messageManager.GetMessageListByWriter(userIdentity.Id);
            return View(values);
        }

        public IActionResult Details(int id)
        {
            var value= messageManager.GetById(id);
            return View(value);
        }
    }
}
