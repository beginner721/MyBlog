using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        MyBlogContext context=new MyBlogContext();
        UserManager<AppUser> _userManager;

        public WriterAboutOnDashboard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync() //ViewComponent async olacaksa InvokeAsync adı verilmeli..
        {
            var userMailTest= await _userManager.FindByNameAsync(User.Identity.Name);
            var userName = User.Identity.Name;
            ViewBag.User = userName;

            string userMail;
            using (MyBlogContext context = new MyBlogContext())
            {
                var test = context.Users.Where(a => a.UserName == userName).Select(a => a.Email).FirstOrDefault();
                userMail = test;
            }

            var writerId= context.Writers.Where(a=> a.Email== userMail).Select(a=> a.Id).FirstOrDefault();
            var values = writerManager.GetWriterById(writerId);
            return View(values);
        }
    }
}
