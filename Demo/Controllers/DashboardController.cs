using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTodo(ToDo toDo)
        {
            ToDoManager toDoManager = new ToDoManager(new EfToDoDal());
            toDo.WriterId = 1;
            toDoManager.Add(toDo);
            return Json("OK");
        }
        [HttpGet]
        public IActionResult DeleteTodo(int id)
        {
            ToDoManager toDoManager = new ToDoManager(new EfToDoDal());
            var todo=toDoManager.GetById(id);
            toDoManager.Delete(todo);
            //toDo.WriterId = 1;
            //toDoManager.Delete(toDo);
            return Json("OK");
        }

    }
}
