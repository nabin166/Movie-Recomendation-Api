using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Api.Model;

namespace Movie_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDBContext movieDBContext;
        public MovieController(MovieDBContext movieDBConetxt)
        {
            this.movieDBContext = movieDBConetxt;
        }

        [HttpGet]
        [Route("Getallmovie")]
        public IEnumerable<Movie> Getallmovie()
        {
           List<Movie> movies = movieDBContext.Movies.ToList();
            return movies;
        }

        [HttpGet]
        [Route("Getonemovie/{id}")]
        public IEnumerable<Movie> Getonemovie(int id)
        {
            //   var MovieDetail = movieDBContext.Movies.Find(id);
            var MovieDetail = movieDBContext.Movies.Where(x => x.MovieId == id).ToList();
            

             
            return MovieDetail;
        }

        [HttpDelete]
        [Route("Removemovie/{id}")]
        public IActionResult Remove(int id)
        {
            var MovieDetail = movieDBContext.Movies.Find(id);
            if (MovieDetail != null)
            {
                movieDBContext.Movies.Remove(MovieDetail);
                movieDBContext.SaveChanges();

                return RedirectToAction("Getallmovie");
            }
            else
            {
                return RedirectToAction("Getallmovie");
            }
        }

        [HttpPost]
        [Route("Addmovie")]

        public IActionResult Addmovie(Movie movie)
        {
            movieDBContext.Movies.Add(movie);
            movieDBContext.SaveChanges();
            return RedirectToAction("Getallmovie");
        }

        [HttpGet]
        [Route("Editmovie/{id}")]

        
        public IActionResult editmovie(Movie movie)
        {

            var MovieDetail = movieDBContext.Movies.Where(x=>x.MovieId == movie.MovieId).FirstOrDefault();
            if (MovieDetail != null)
            {
                MovieDetail.Movie_Name = movie.Movie_Name;
                MovieDetail.Director_Name = movie.Director_Name;
                MovieDetail.Movie_Description = movie.Movie_Description;
                MovieDetail.Rating = movie.Rating;
                MovieDetail.Lead_Actor = movie.Lead_Actor;
                MovieDetail.Gnere_id = movie.Gnere_id;


                movieDBContext.SaveChanges();
                return RedirectToAction("Getallmovie");
            }
            else
            {
                return RedirectToAction("Getallmovie");
            }


        }




    }
}
