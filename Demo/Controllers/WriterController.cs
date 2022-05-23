using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Demo.Models;
using Entities.Concrete;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public WriterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.Name = usermail;
            MyBlogContext context = new MyBlogContext();
            var writerName = context.Writers.Where(a => a.Email == usermail).Select(b => b.FirstName).FirstOrDefault();
            ViewBag.Name2 = writerName;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserProfileViewModel userViewModel = user.Adapt<UserProfileViewModel>();
            return View(userViewModel);
        }

        [HttpPost]
        //Bu kısımlardaki if else'ler düzenlenecek ve daha sade hale getirilecek.
        public async Task<IActionResult> EditProfile(UserProfileViewModel userViewModel, AddProfileImage formImage)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            bool isTrue = await _userManager.CheckPasswordAsync(user, userViewModel.Password);
            if (isTrue)
            {
                //IMAGE ADD SYSTEM...
                user.NameSurname = userViewModel.NameSurname;
                user.UserName= userViewModel.UserName;
                user.Email= userViewModel.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    await _signInManager.SignOutAsync();
                    //eğer giriş çıkış işlemi yapılmaz ise cookie da eski bilgileri kalıyor, ve tekrar editprofile sayfasına girince
                    //güncel değişmiş bilgilerini göremiyor, çünkü kullanıcı adını değiştirdi, cookie dan mevcut user'ı yakalayamıyoruz...
                    await _signInManager.SignInAsync(user,true);
                    return View(); //ilk denemesinde hata mesajı aldıysa View'e dönmesi lazım ki hata mesajı frontendden silinsin.

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            ModelState.AddModelError("Password", "Girilen şifre hatalı...");
            return View(userViewModel);

            //WriterValidator validator = new WriterValidator();
            //ValidationResult result = validator.Validate(writer);
            //var writerOldData = writerManager.GetById(writer.Id);
            //if (writerOldData.Password == writer.Password && result.IsValid)
            //{
            //    if (formImage.Image != null)
            //    {
            //        var extension = Path.GetExtension(formImage.Image.FileName);
            //        var imageName =  Guid.NewGuid() + extension;
            //        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", imageName);
            //        var stream = new FileStream(location, FileMode.Create);
            //        formImage.Image.CopyTo(stream);
            //        writer.Image = "WriterImageFiles/"+ imageName;
            //    }
            //    else
            //    {
            //        writer.Image = writerOldData.Image;
            //    }


            //    writerManager.Update(writer);
            //    return RedirectToAction("Index", "Dashboard");


            //}
            //else
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }

            //}



        }

        //Alt kısımlara ihtiyacımız yok , görsel yükleme kısmı edit profile kısmına eklendi. Add actionları ve view'ları silinecek.
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add(AddProfileImage writer)
        {
            Writer wr = new Writer();
            if (writer.Image != null)
            {
                var extension = Path.GetExtension(writer.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                writer.Image.CopyTo(stream);
                wr.Image = newImageName;

            }
            else
            {
                return View();
            }
            wr.Email = writer.Email;
            wr.LastName = writer.LastName;
            wr.FirstName = writer.FirstName;
            wr.Password = writer.Password;
            wr.Status = true;
            wr.About = writer.About;
            writerManager.Add(wr);
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult PasswordChange(PasswordChangeModel passwordModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                var result = _userManager.ChangePasswordAsync(user,passwordModel.OldPass,passwordModel.NewPass).Result;
                if (result.Succeeded)
                {
                    _userManager.UpdateSecurityStampAsync(user);
                    _signInManager.SignOutAsync();
                    _signInManager.PasswordSignInAsync(user, passwordModel.NewPass, true, false);
                    return RedirectToAction("EditProfile", "Writer");
                }
                else
                {
                    string errors = "";
                    foreach (var error in result.Errors)
                    {
                        errors+= error.Description + " ";
                    }
                    TempData["PasswordError"] = errors;
                    return RedirectToAction("EditProfile");

                }
            }
            else
            {
                TempData["PasswordError"] = "Şifreler hatalı.";
                return RedirectToAction("EditProfile");
            }
                
            

        }
    }
}
