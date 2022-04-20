using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [AllowAnonymous]
    public class ApiArticleController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44394/api/articles/getall");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<ArticleRootObject>(jsonString);
            var listOfArticle = results.data;

            return View(listOfArticle);
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

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(jsonArticle);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateArticle(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44394/api/articles/get/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var results = JsonConvert.DeserializeObject<OneArticleRootObject>(jsonString);
                var data = results.data;

                return View(data);

            }


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArticle(ArticleApi data)
        {
            var httpClient = new HttpClient();
            var jsonArticle= JsonConvert.SerializeObject(data);

            StringContent content= new StringContent(jsonArticle, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44394/api/articles/update", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
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

    class OneArticleRootObject
    {
        public ArticleApi data { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }
    class ArticleRootObject
    {
        public List<ArticleApi> data { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }
    public class ArticleApi
    {
        public string id { get; set; }
        public string categoryid { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime creationdate { get; set; }
        public bool status { get; set; }
    }
}
