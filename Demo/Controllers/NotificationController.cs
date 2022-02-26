using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
