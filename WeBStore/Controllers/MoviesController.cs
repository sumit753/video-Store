using System.Collections.Generic;
using System.Web.Mvc;
using WeBStore.Models;
using WeBStore.ViewModel;
namespace WeBStore.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

            [Route("movies/random")]
    
        public ActionResult Random()
        {
            var movie = new Movie() { Id =1,Name="Shrek" };
            var customers = new List<Customer>()
                            {
                               new Customer {Id=1,Name="Sumit" },
                               new Customer { Id=2,Name="Amit"}
                               
                            };

            var ViewModel = new CustomerMovie()
            {
                Movie = movie,
                CustomerList = customers
            };
            return View(ViewModel);
        }
    }
}