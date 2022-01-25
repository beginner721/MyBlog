using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.ViewComponents.Article
{
    public class LastThreeArticle:ViewComponent
    {
        ArticleManager articleManager = new ArticleManager(new EfArticleDal());
        public IViewComponentResult Invoke()
        {
            //This component returns IOrderedEnumerable (because we used descending), for this reason; in cshtml page model type must be same with returns.
            var articles = articleManager.GetLastThreeBlog().OrderByDescending(a=> a.CreateDate );
            return View(articles);
        }
        
    }
}
