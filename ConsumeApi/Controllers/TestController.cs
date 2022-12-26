using ConsumeApi.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Movie_Api.Model;
using Newtonsoft.Json;

namespace ConsumeApi.Controllers
{
    public class TestController : Controller
    {

        //Get Request Handle
        public async Task<IActionResult> Index(List<Genrevm> genrevms)
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

                List<Genrevm> UserList = JsonConvert.DeserializeObject<List<Genrevm>>(data);


                //  list = JsonConvert.DeserializeObject(data);


                // viewmModel add
                foreach (var item in UserList)
                {

                    Genrevm genrevm = new Genrevm();
                    genrevm.Genre_Id = item.Genre_Id;
                    genrevm.Genre_Name = item.Genre_Name;
                    genrevms.Add(genrevm);


                }



                ViewBag.Result = genrevms;




                // List<da> c =  JsonSerializer.Deserialize<string>(data);



                return View();
            }

            return View();
        }

        //Post Request Handle
        public async Task<IActionResult> Creategenre()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Postgenre(Genre genre, string Genrename)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7021/api/Genre/Addgenre");

            genre.Genre_Name = Genrename;

            var result = await client.PostAsJsonAsync(client.BaseAddress, genre);



            return RedirectToAction("Index");
        }


        
        public async  Task<IActionResult> Remove(int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7021/api/Genre/Removegenre/");

            client.DeleteAsync(id.ToString()).Wait();
           
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        //Getone from ---id---
        public async Task<IActionResult> Edit(List<Genrevm> genrevms , int id)
        {




            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7021/api/Genre/");


            //Get 
            var task = client.GetAsync("Getonegenre/"+id);

            task.Wait();
            var result = task.Result;

            if (result.IsSuccessStatusCode)
            {
                var resulttask = result.Content.ReadAsStringAsync();
                resulttask.Wait();

                var data = resulttask.Result;

                List<Genrevm> UserList = JsonConvert.DeserializeObject<List<Genrevm>>(data);


                //  list = JsonConvert.DeserializeObject(data);


                // viewmModel add
                foreach (var item in UserList)
                {

                    Genrevm genrevm = new Genrevm();
                    genrevm.Genre_Id = item.Genre_Id;
                    genrevm.Genre_Name = item.Genre_Name;
                    genrevms.Add(genrevm);


                }



                ViewBag.Result = genrevms;




                // List<da> c =  JsonSerializer.Deserialize<string>(data);



                return View();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editgenre(Genre genre, string Genrename , int id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7021/api/Genre/Editgenre/"+id);

            genre.Genre_Name = Genrename;

            var result = await client.PostAsJsonAsync(client.BaseAddress, genre);



            return RedirectToAction("Index");
        }


    }
}
