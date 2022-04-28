using DataAccess.Concrete.EntityFramework;
using Demo.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userViewModel.Username, userViewModel.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı giriş denemesi.");
                    //return RedirectToAction("Index", "Login");
                }
            }
            return View();

        }

        //[HttpPost]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //    MyBlogContext context = new MyBlogContext();
        //    var dataValue = context.Writers.FirstOrDefault(a => a.Email == writer.Email && a.Password == writer.Password);
        //    if (dataValue!= null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,writer.Email)
        //        };
        //        var userId = new ClaimsIdentity(claims,"x");
        //        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userId);
        //        await HttpContext.SignInAsync(claimsPrincipal);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }


}
