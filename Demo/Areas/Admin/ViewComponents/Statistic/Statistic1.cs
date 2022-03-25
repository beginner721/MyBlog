using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Demo.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace Demo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            using (MyBlogContext blogContext = new MyBlogContext())
            {
                ViewBag.TotalArticles = blogContext.Articles.Count();
                ViewBag.TotalMessages = blogContext.Contacts.Count();
                ViewBag.TotalComments = blogContext.Comments.Count();

                string api = "398ac5b3b06afebdfd962808eacd9fa7";
                string city = "batman";
                string connection = "https://api.openweathermap.org/data/2.5/weather?q="+city+ "&mode=xml&lang=tr&units=metric&appid=" + api;
                XDocument document=XDocument.Load(connection);
                ViewBag.Temp = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                ViewBag.Air = document.Descendants("weather").ElementAt(0).Attribute("value").Value;
            }
            return View();
        }
    }
}
