using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Api.Model;

namespace Movie_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        private readonly MovieDBContext movieDBContext;
        public GenreController(MovieDBContext movieDBConetxt)
        {
            this.movieDBContext = movieDBConetxt;
        }

         [HttpGet]
        [Route("Getallgenre")]
        public IEnumerable<Genre> Getallmovie()
        {
            List<Genre> genres = movieDBContext.Genres.ToList();
            return genres;
        }

        [HttpGet]
        [Route("Getonegenre/{id}")]
        public IEnumerable<Genre> Getonegenre(int id)
        {
           // List<Genre> MovieDetail = movieDBContext.Movies.Find(id);
             List<Genre> genr = movieDBContext.Genres.Where(x => x.Genre_Id == id).ToList();
            return genr;



        }

        [HttpDelete]
        [Route("Removegenre/{id}")]
        public IActionResult Remove(int id)
        {
            var GenreDetail = movieDBContext.Genres.Find(id);
            if (GenreDetail != null)
            {
                movieDBContext.Genres.Remove(GenreDetail);
                movieDBContext.SaveChanges();

                return RedirectToAction("Getallgenre");
            }
            else
            {
                return RedirectToAction("Getallgenre");
            }
        }

        [HttpPost]
        [Route("Addgenre")]

        public IActionResult Addmovie(Genre genre)
        {
            movieDBContext.Genres.Add(genre);
            movieDBContext.SaveChanges();
            return RedirectToAction("Getallgenre");
        }

        [HttpPost]
        [Route("Editgenre/{id}")]


        public IActionResult editmovie(Genre genre , int id)
        {

            var genreDetail = movieDBContext.Genres.Where(x => x.Genre_Id == id).FirstOrDefault();
            if (genreDetail != null)
            {

                genreDetail.Genre_Name = genre.Genre_Name;
                

                movieDBContext.SaveChanges();
                return RedirectToAction("Getallgenre");
            }
            else
            {
                return RedirectToAction("Getallgenre");
            }


        }


    }
}
