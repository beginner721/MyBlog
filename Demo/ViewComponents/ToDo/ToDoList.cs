using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Demo.ViewComponents.ToDo
{
    public class ToDoList:ViewComponent
    {
        ToDoManager toDo = new ToDoManager(new EfToDoDal());
        public  IViewComponentResult Invoke()
        {
            var values = toDo.GetTodoByWriter(1);
            return View(values);  
        }
    }
}
