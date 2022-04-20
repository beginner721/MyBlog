using Demo.Areas.LocalApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Areas.LocalApi.Controllers
{
    [Area("LocalApi")]
    [AllowAnonymous]
    public class CategoryApiController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44394/api/categories/getall");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<CategoryListRootObject>(jsonString);
            var listOfData = results.data;


            //var result = (JObject)JsonConvert.DeserializeObject(jsonString);
            //var data = result.SelectToken("data").Values(); //this process gets directly data list...


            return View(listOfData);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryApi category)
        {
            var httpClient = new HttpClient();
            var jsonCategory = JsonConvert.SerializeObject(category);

            StringContent content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44394/api/categories/add", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44394/api/categories/get/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonCategory = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<OneCategoryRootObject>(jsonCategory);

                var getData = value.data;
                return View(getData);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryApi category)
        {
            var httpClient = new HttpClient();
            var jsonCategory = JsonConvert.SerializeObject(category);

            var content = new StringContent(jsonCategory, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44394/api/categories/update", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44394/api/categories/delete/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
