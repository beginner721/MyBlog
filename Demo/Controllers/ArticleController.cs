
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [AllowAnonymous]
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
            //Bu method aslında GetById olmalı, tek bir Article'ı döndürüyor. List döndürmesine gerek yok. View'ı ile birlikte düzeltilecek.
            return View(article);
        }
    }
}
