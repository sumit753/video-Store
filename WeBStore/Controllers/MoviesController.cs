using System.Collections.Generic;
using System.Web.Mvc;
using WeBStore.Models;
using WeBStore.ViewModel;
using System.Linq;
namespace WeBStore.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [Route("movies")]
        public ActionResult Index()
        {
            var Movies = GetMovies();
            return View(Movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

       
        //following code was to test ViewModel demo

       // [Route("movies/random")]
       //public ActionResult Random()
       // {
       //     var movie = new Movie() { Id =1,Name="Shrek" };
       //     var customers = 

       //     var ViewModel = new CustomerMovie()
       //     {
       //         Movie = movie,
       //         CustomerList = customers
       //     };
       //     return View(ViewModel);
       // }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
                            {
                               new Movie {Id=1,Name="AgniPath" },
                               new Movie { Id=2,Name="Shagird"},
                               new Movie {Id=3,Name="Lagaan" },
                               new Movie {Id=4,Name="Shrik" },
                               new Movie {Id=5,Name="KudvenkatSeries" },
                                new Movie {Id=6,Name="Algorithm" },
                                new Movie {Id=7,Name="Sarforsh" }

                                 };
        }
    }
}