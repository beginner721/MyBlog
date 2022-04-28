using Demo.Areas.LocalApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Areas.LocalApi.Controllers
{
    [Area("LocalApi")]
    [AllowAnonymous]
    public class ArticleApiController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var httpClient = new HttpClient();
                var responseMessage = await httpClient.GetAsync("https://localhost:44394/api/articles/getall");
                var jsonString = await responseMessage.Content.ReadAsStringAsync();

                var results = JsonConvert.DeserializeObject<ArticleListRootObject>(jsonString);
                if (results.success == "true")
                {
                    var listOfArticle = results.data;
                    return View(listOfArticle);
                }
                else
                {
                    if (results.message == "null")
                    {
                        ViewBag.ErrorMessage = "Bir hata meydana geldi.";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = results.message;
                    }
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.InnerException.Message;
                return View();
                
            }

            
            
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleApi data)
        {
            var httpClient = new HttpClient();
            var jsonArticle = JsonConvert.SerializeObject(data);

            StringContent content = new StringContent(jsonArticle, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44394/api/articles/add", content);
            var jsonString = await responseMessage.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<OneArticleRootObject>(jsonString);
            

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (results.message=="null")
                {
                    ViewBag.ErrorMessage = "Bir hata meydana geldi.";
                }
                else
                {
                    ViewBag.ErrorMessage = results.message;
                }
                return View(data);
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> UpdateArticle(int id)
        {
            try
            {
                var httpClient = new HttpClient();
                var responseMessage = await httpClient.GetAsync("https://localhost:44394/api/articles/get/" + id);

                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<OneArticleRootObject>(jsonString);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return View(results.data);

                }
                else
                {
                    return View(results.message);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.InnerException.Message;
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> UpdateArticle(ArticleApi data)
        {
            var httpClient = new HttpClient();
            var jsonArticle = JsonConvert.SerializeObject(data);

            StringContent content = new StringContent(jsonArticle, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44394/api/articles/update", content);
            
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var results= JsonConvert.DeserializeObject<OneArticleRootObject>(jsonString);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage= results.message;
                return View(data);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44394/api/articles/delete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    
}
