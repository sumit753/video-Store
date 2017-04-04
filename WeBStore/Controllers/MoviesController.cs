using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WeBStore.Models;
namespace WeBStore.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        [Route("movies")]
        public ActionResult Index()
        {
            var Movies = _context.Movies.ToList();
            return View(Movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == Id);

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


    }
}