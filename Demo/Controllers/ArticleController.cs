
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class ArticleController : Controller
    {
        ArticleManager articleManager = new ArticleManager(new EfArticleDal());
        public IActionResult Index()
        {
            var articles = articleManager.GetAllWithCategory();
            return View(articles);
        }
        public IActionResult ReadMore(int id)
        {
            ViewBag.id = id;
            var article = articleManager.GetArticleById(id);
            return View(article);
        }
    }
}
