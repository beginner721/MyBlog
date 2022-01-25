using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer writer)
        {
            MyBlogContext context = new MyBlogContext();
            var dataValue = context.Writers.FirstOrDefault(a => a.Email == writer.Email && a.Password == writer.Password);
            if (dataValue!= null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,writer.Email)
                };
                var userId = new ClaimsIdentity(claims,"x");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userId);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }
        }
    }

//    MyBlogContext context = new MyBlogContext();
//    var dataValue = context.Writers.FirstOrDefault(a => a.Email == writer.Email && a.Password == writer.Password);
//            if (dataValue!=null)
//            {
//                HttpContext.Session.SetString("username",writer.Email);
//                return RedirectToAction("Index","Writer");
//}
//            else
//{
//    return View();
//}
}
