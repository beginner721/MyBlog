using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Demo.ViewComponents.Article
{
    public class ArticleListInDashboard:ViewComponent
    {
        ArticleManager articleManager = new ArticleManager(new EfArticleDal());
        public IViewComponentResult Invoke()
        {
            
            var articles = articleManager.GetAllWithCategory();
            return View(articles);
        }
    }
}
