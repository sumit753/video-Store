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

    public ActionResult NewMovie()
    {
        var genres = _context.Genres.ToList();

        var viewModel = new MovieFormViewModel
        {
            Genres = genres,
            Formheading = "Add New Movie"

        };

        return View("MoviesForm", viewModel);
    }

    [HttpPost]
    public ActionResult Save(MovieFormViewModel viewmodel)
    {
        if (viewmodel.Movies.Id == 0)
        {
            viewmodel.Movies.DateAdded = DateTime.Now;
            _context.Movies.Add(viewmodel.Movies);
        }
        else
        {
            var MovieInDb = _context.Movies.Single(m => m.Id == viewmodel.Movies.Id);

            MovieInDb.Name = viewmodel.Movies.Name;
            MovieInDb.NumberInStock = viewmodel.Movies.NumberInStock;
            MovieInDb.ReleaseDate = viewmodel.Movies.ReleaseDate;
            MovieInDb.GenreId = viewmodel.Movies.GenreId;


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




}
