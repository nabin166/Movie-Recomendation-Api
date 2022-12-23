using Microsoft.AspNetCore.Mvc;
using Movie_Api.Model;
using Newtonsoft.Json;
using System.Text.Json;

namespace ConsumeApi.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7021/api/Genre/");


            //Get 
            var task = client.GetAsync("Getallgenre");

            task.Wait();
            var result = task.Result;

            if (result.IsSuccessStatusCode)
            {
                var resulttask = result.Content.ReadAsStringAsync();
                resulttask.Wait();

                var data = resulttask.Result;


               // List<da> c =  JsonSerializer.Deserialize<string>(data);
                List<Genre> UserList = JsonConvert.DeserializeObject<List<Genre>>(data);
                ViewBag.Result = UserList;
           
                return View();
            }

            return View();
        }
    }
}
