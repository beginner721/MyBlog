using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            var commentList = new List<UserComment>
            {
                new UserComment
                {
                    Id=1,
                    Username="Baran"
                },
                new UserComment
                {
                    Id=2,
                    Username="Deneme"
                },
                new UserComment
                {
                    Id=3,
                    Username="Demo"
                }
            };
            return View(commentList);
        }
    }
}
