using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{

    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer writer)
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
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
