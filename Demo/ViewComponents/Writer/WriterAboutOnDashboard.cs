using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Demo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        MyBlogContext context=new MyBlogContext();
        public IViewComponentResult Invoke()
        {
            var user = User.Identity.Name;
            var writerId= context.Writers.Where(a=> a.Email== user).Select(a=> a.Id).FirstOrDefault();
            var values = writerManager.GetWriterById(writerId);
            return View(values);
        }
    }
}
