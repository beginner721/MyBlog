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
            MyBlogContext context= new MyBlogContext();
            var user = User.Identity.Name;
            var writerId = context.Writers.Where(a => a.Email == user).Select(a => a.Id).FirstOrDefault();
            var articles = articleManager.GetAllByWriter(writerId);
            return View(articles);
        }
    }
}
