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
        public IEnumerable<Movie> Getonegenre(int id)
        {
            //   var MovieDetail = movieDBContext.Movies.Find(id);
            var MovieDetail = movieDBContext.Movies.Where(x => x.MovieId == id).ToList();



            return MovieDetail;
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

        [HttpGet]
        [Route("Editgenre/{id}")]


        public IActionResult editmovie(Genre genre)
        {

            var genreDetail = movieDBContext.Genres.Where(x => x.Genre_Id == genre.Genre_Id).FirstOrDefault();
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
