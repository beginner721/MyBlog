using Demo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters= JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult AddWriter(Writer writer)
        {
            writers.Add(writer);
            var jsonWriters= JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult DeleteWriter(int id)
        {
            var writer =writers.FirstOrDefault(a=> a.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }
        [HttpPost]
        public IActionResult UpdateWriter(Writer wr)
        {
            var writer = writers.FirstOrDefault(a => a.Id == wr.Id);
            writer.Name = wr.Name;
            var jsonWriter = JsonConvert.SerializeObject(wr);
            return Json(jsonWriter);
        }
        public IActionResult GetWriterById(int id)
        {
            var findWriter= writers.FirstOrDefault(a=> a.Id== id);
            var jsonWriters= JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        public static List<Writer> writers = new List<Writer>
        {
            new Writer
            {
                Id =1,
                Name="Baran"
            },
            new Writer
            {
                Id =2,
                Name="Ahmet"
            }, new Writer
            {
                Id =3,
                Name="Kerem"
            },
        };
    }
}
