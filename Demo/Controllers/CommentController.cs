using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.Status = true;
            comment.ArticleId = 5;
            commentManager.Add(comment);
            return Json("OK");
        }
        //public PartialViewResult PartialCommentListByArticle(int id)
        //{
        //    var commentList= commentManager.GetAll(id);
        //    return PartialView(commentList);
        //}
       
    }
}
