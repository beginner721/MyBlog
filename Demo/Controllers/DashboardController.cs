using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Demo.Controllers
{
    
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            MyBlogContext context = new MyBlogContext();

            ViewBag.TotalArticleCount = context.Articles.Count().ToString();
            ViewBag.TotalArticleCountByWriter = context.Articles.Where(a => a.WriterId == 1).Count().ToString();

            var data = context.Articles.Where(a => a.CreateDate >= System.DateTime.Now.AddDays(-7)).Count().ToString();
            ViewBag.TotalArticleCountThisWeek = data;

            return View();
        }

        [HttpPost]
        public IActionResult AddTodo(ToDo toDo)
        {
            ToDoValidator validate = new ToDoValidator();
            ValidationResult result = validate.Validate(toDo);
            if (result.IsValid)
            {
                ToDoManager toDoManager = new ToDoManager(new EfToDoDal());
                toDo.WriterId = 1;
                toDoManager.Add(toDo);
                return Json("OK");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    //throw new System.Exception(error.ErrorMessage);
                    //Hata mesajını ajaxa gönderemedim, düzeltilebilir.
                }
                return Json("");

            }

        }
        [HttpPost]
        public IActionResult DeleteTodo(int id)
        {
            ToDoManager toDoManager = new ToDoManager(new EfToDoDal());
            var todo = toDoManager.GetById(id);
            toDoManager.Delete(todo);
            return Json("OK");
        }

    }
}
