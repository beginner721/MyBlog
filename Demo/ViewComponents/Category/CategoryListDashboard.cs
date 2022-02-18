using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Demo.ViewComponents.Category
{
    public class CategoryListDashboard:ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public IViewComponentResult Invoke()
        {
            var categories = categoryManager.GetAll();
            return View(categories);
        }
    }
}
