using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index(int? page)
        {
            var pageNumber= page ?? 1;
            var onePageOfCategories= categoryManager.GetAll().ToPagedList(pageNumber,3);
            return View(onePageOfCategories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            CategoryValidator validator= new CategoryValidator();
            ValidationResult results= validator.Validate(category);
            if (results.IsValid)
            {
                category.Status = true;
                categoryManager.Add(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            
            var value= categoryManager.GetById(id);
            categoryManager.Delete(value);
            return RedirectToAction("Index");
        }
    }
}
