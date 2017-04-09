using System.Web.Mvc;

namespace WeBStore.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult NewRental()
        {
            return View();
        }
    }
}