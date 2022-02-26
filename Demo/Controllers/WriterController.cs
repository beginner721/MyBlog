using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Demo.Models;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Index()
        {
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult EditProfile()
        {
            var writerValue = writerManager.GetById(1);
            ViewBag.Image = writerValue.Image;
            return View(writerValue);
        }
        [AllowAnonymous]
        [HttpPost]
        //Bu kısımlardaki if else'ler düzenlenecek ve daha sade hale getirilecek.

        public IActionResult EditProfile(Writer writer, AddProfileImage formImage)
        {
            var writerOldData = writerManager.GetById(writer.Id);
            if (writerOldData.Password == writer.Password)
            {
                WriterValidator validator = new WriterValidator();
                ValidationResult result = validator.Validate(writer);
                if (result.IsValid)
                {
                    writerManager.Update(writer);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }

            }
            else
            {
                TempData["error"] = "Eski şifre hatalı.";
            }

            if (formImage.Image!=null)
            {
                var extension = Path.GetExtension(formImage.Image.FileName);
                var imageName=Guid.NewGuid() + extension;
                var location= Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles",imageName);
                var stream= new FileStream(location, FileMode.Create);
                formImage.Image.CopyTo(stream);
                writer.Image = imageName;
            }
            else
            {
                writer.Image = writerOldData.Image;
            }

            return View();
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
            if (writer.Image!=null)
            {
                var extension= Path.GetExtension(writer.Image.FileName);
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
            wr.Email=writer.Email;
            wr.LastName=writer.LastName;
            wr.FirstName=   writer.FirstName;
            wr.Password=writer.Password;
            wr.Status = true;
            wr.About=writer.About;
            writerManager.Add(wr);
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult PasswordChange(string oldPass ,string newPass, string newPassAgain)
        {
            var writerData = writerManager.GetById(1);

            if (oldPass != null && writerData.Password== oldPass)
            {
                if (newPass== newPassAgain)
                {
                    writerData.Password= newPass;
                    writerManager.Update(writerData);
                    TempData["success"] = "Şifre değiştirme işlemi başarılı.";
                    return RedirectToAction("EditProfile", "Writer");
                }
               
            }
            TempData["error"] = "Eski şifre hatalı.";
            return RedirectToAction("EditProfile", "Writer");

        }
    }
}
