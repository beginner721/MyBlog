using ClosedXML.Excel;
using DataAccess.Concrete.EntityFramework;
using Demo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {

        public IActionResult ArticleListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelArticleList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Makale listesi");
                workSheet.Cell(1, 1).Value = "Makale ID";
                workSheet.Cell(1, 2).Value = "Makale Adı";

                int blogRowCount = 2;
                foreach (var article in GetArticleListDynamic())
                {
                    workSheet.Cell(blogRowCount, 1).Value = article.Id;
                    workSheet.Cell(blogRowCount, 2).Value = article.Name;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    //return File(content, "application / vnd.openxmlformats - officedocument.spreadsheetml.sheet","Makaleler.xlsx");
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Makaleler.xlsx");
                }
            }
        }
        public List<ArticleForExcelModel> GetArticleListDynamic()
        {
            List<ArticleForExcelModel> articles=new List<ArticleForExcelModel>();
            using (var context= new MyBlogContext())
            {
                articles = context.Articles.Select(a => new ArticleForExcelModel
                {
                    Id = a.Id,
                    Name = a.Title
                }).ToList();
            }
            return articles;
        }
    }
}
