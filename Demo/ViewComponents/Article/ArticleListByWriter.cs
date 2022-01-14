using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.ViewComponents.Article
{
    public class ArticleListByWriter : ViewComponent
    {
        ArticleManager articleManager = new ArticleManager(new EfArticleDal());

        public IViewComponentResult Invoke()
        {
            var articles = articleManager.GetAllByWriter(1);
            return View(articles);
        }
    }
}
