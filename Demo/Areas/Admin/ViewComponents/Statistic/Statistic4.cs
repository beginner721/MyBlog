using Microsoft.AspNetCore.Mvc;

namespace Demo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
