using Demo.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        UserManager<AppUser> _userManager;
        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                //if (userViewModel.CheckBox==false)
                //{
                //    ModelState.AddModelError("CheckBox", "*Kullanım koşulları kabul edilmeli");
                //    return View(userViewModel);
                //}
                AppUser user = new AppUser()
                {
                    Email = userViewModel.Email,
                    UserName = userViewModel.Username,
                    NameSurname = userViewModel.NameSurname
                };
                var result = await _userManager.CreateAsync(user,userViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(userViewModel);
        }

    }
}
