using Demo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<Category> list = new List<Category>();

            list.Add(new Category { categorycount = 10 , categoryname = "Teknoloji"});
            list.Add(new Category { categorycount = 14 , categoryname = "Yazılım"});
            list.Add(new Category { categorycount = 5 , categoryname = "Finans"});

            return Json(new {jsonlist=list});
        }
    }
}
