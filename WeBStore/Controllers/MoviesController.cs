using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using WeBStore.Models;
using WeBStore.ViewModel;

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
        //var Movies = _context.Movies.ToList();
        if (User.IsInRole(RoleName.CanManageMovies))
            return View("List");

        return View("ReadonlyList");
    }

    public ActionResult Details(int Id)
    {
        var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == Id);

        if (movie == null)
            return HttpNotFound();

        return View(movie);

    }

    [Authorize(Roles = RoleName.CanManageMovies)]
    public ActionResult NewMovie()
    {
        var genres = _context.Genres.ToList();

        var viewModel = new MovieFormViewModel
        {
            Genres = genres


        };

        return View("MoviesForm", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Movie movie)
    {
        if (movie.Id == 0)
        {
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
        }
        else
        {
            var MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);

            MovieInDb.Name = movie.Name;
            MovieInDb.NumberInStock = movie.NumberInStock;
            MovieInDb.ReleaseDate = movie.ReleaseDate;
            MovieInDb.GenreId = movie.GenreId;


        }
        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
        }
        return RedirectToAction("Index", "Movies");
    }

    public ActionResult Edit(int Id)
    {
        var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

        if (movie == null)
            return HttpNotFound();

        var viewModel = new MovieFormViewModel(movie)
        {

            Genres = _context.Genres.ToList()
        };


        return View("MoviesForm", viewModel);

    }


}
