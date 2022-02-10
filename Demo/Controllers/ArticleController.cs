
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [AllowAnonymous]
    public class ArticleController : Controller
    {
        ArticleManager articleManager = new ArticleManager(new EfArticleDal());
        public IActionResult Index()
        {
            var articles = articleManager.GetAllWithCategory();
            return View(articles);
        }
        public IActionResult ReadMore(int id)
        {
            ViewBag.id = id;
            var article = articleManager.GetArticleById(id);
            //Bu method aslında GetById olmalı, tek bir Article'ı döndürüyor. List döndürmesine gerek yok. View'ı ile birlikte düzeltilecek.
            return View(article);
        }
        [HttpGet]
        public IActionResult ArticleListByWriter()
        {
            var values = articleManager.GetAllByWriter(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddArticle()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryList = (from a in categoryManager.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = a.Name,
                                                     Value = a.Id.ToString()
                                                 }).ToList();
            //List<SelectListItem> articles = (from a in articleManager.GetAllWithCategory()
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = a.Category.ToString(),
            //                                     Value = a.CategoryId.ToString()
            //                                 }).ToList();
            ViewBag.CategoryValues = categoryList;
            return View();
        }
        [HttpPost]
        public IActionResult AddArticle(Article article)
        {
            ArticleValidator validations = new ArticleValidator();
            ValidationResult result = validations.Validate(article);
            if (result.IsValid)
            {
                article.Status = true;
                article.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                article.WriterId = 1;// Burası writera göre ayarlanacak.
                articleManager.Add(article);
                return RedirectToAction("ArticleListByWriter", "Article");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}
