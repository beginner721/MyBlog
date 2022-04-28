
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
    public class ArticleController : Controller
    {
        ArticleManager articleManager = new ArticleManager(new EfArticleDal());
        [AllowAnonymous]
        public IActionResult Index()
        {
            var articles = articleManager.GetAllWithCategory();
            return View(articles);
        }
        [AllowAnonymous]
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
            MyBlogContext context = new MyBlogContext();
            var user = User.Identity.Name;
            var writerId = context.Writers.Where(a => a.Email == user).Select(a => a.Id).FirstOrDefault();
            var values = articleManager.GetAllWithCategoryByWriter(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddArticle()
        {
            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            //List<SelectListItem> categoryList = (from a in categoryManager.GetAll()
            //                                     select new SelectListItem
            //                                     {
            //                                         Text = a.Name,
            //                                         Value = a.Id.ToString()
            //                                     }).ToList();
            ViewBag.CategoryValues = GetCategoryList();
            return View();
        }
        [HttpPost]
        public IActionResult AddArticle(Article article)
        {
            ViewBag.CategoryValues = GetCategoryList();
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
        public IActionResult Delete(int id)
        {
            var article = articleManager.GetById(id);
            articleManager.Delete(article);
            return RedirectToAction("ArticleListByWriter","Article");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var blogValue= articleManager.GetById(id);
            ViewBag.CategoryValues = GetCategoryList();
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult Edit(Article article)
        {
            article.WriterId = 1;
            article.Status = true;
            articleManager.Update(article);
            return RedirectToAction("ArticleListByWriter");
        }
        
        private List<SelectListItem> GetCategoryList()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            List<SelectListItem> categoryList = (from a in categoryManager.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = a.Name,
                                                     Value = a.Id.ToString()
                                                 }).ToList();

            return categoryList;
        }
    }
}
