using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WeBStore.Models;

namespace WeBStore.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(m => m.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }


    }
}