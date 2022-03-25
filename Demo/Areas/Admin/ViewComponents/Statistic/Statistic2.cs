using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Demo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (MyBlogContext blogContext = new MyBlogContext())
            {
                ViewBag.LastArticle = blogContext.Articles.OrderBy(a=> a.CreateDate).Last().Title.ToString();
                ViewBag.TotalMessages = blogContext.Contacts.Count();
                ViewBag.TotalComments = blogContext.Comments.Count();
            }
            return View();
        }
    }
}
