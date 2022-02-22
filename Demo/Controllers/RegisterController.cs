using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer writer,string pass2)
        {
            //Bu kısımlardaki if else'ler düzenlenecek ve daha sade hale getirilecek.
            if (writer.Password!=pass2)
            {
                //add model errorda ilk parametre frontend kısmında name kısmına denk geliyor.
                ModelState.AddModelError("password", "Şifreler uyuşmuyor.");

            }
            else
            {
                WriterValidator validationRules = new WriterValidator();
                ValidationResult results = validationRules.Validate(writer);
                if (results.IsValid)
                {
                    writer.Status = true;
                    writer.About = "Boş";
                    writerManager.Add(writer);
                    return RedirectToAction("Index", "Article");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
           
            return View();
            
        }
    }
}
