using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [AllowAnonymous]
    public class ApiTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44394/api/categories/getall");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<DataRootObject>(jsonString);
            var listOfData = results.data;


            //var result = (JObject)JsonConvert.DeserializeObject(jsonString);
            //var data = result.SelectToken("data").Values(); //this process gets directly data list...


            return View(listOfData);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Data category)
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
                var value = JsonConvert.DeserializeObject<OneDataRootObject>(jsonCategory);

                var getData = value.data;
                return View(getData);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Data category)
        {
            var httpClient = new HttpClient();
            var jsonCategory = JsonConvert.SerializeObject(category);

            var content= new StringContent(jsonCategory,Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44394/api/categories/update",content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

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


    public class OneDataRootObject
    {//This class for one data, not List of Data
        public Data data { get; set; }
        public string success { get; set; }
        public string message { get; set; }
    }
    public class DataRootObject
    {
        public List<Data> data { get; set; }
        public string success { get; set; }
        public string message { get; set; }
    }
    public class Data
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
    }
}
