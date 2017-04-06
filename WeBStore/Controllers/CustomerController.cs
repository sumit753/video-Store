using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WeBStore.Models;
using WeBStore.ViewModel;

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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFomViewModel
            {
                //By using new Customer() we intitalized customer class with default values
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFomViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);


            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeID = customer.MembershipTypeID;
                customerInDb.isSubscribedToNewsletter = customer.isSubscribedToNewsletter;
                customerInDb.DateOfBirth = customer.DateOfBirth;


            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var Customers = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (Customers == null)
                HttpNotFound();

            var viewModel = new CustomerFomViewModel
            {
                Customer = Customers,
                MembershipTypes = _context.MembershipTypes.ToList()
            };



            return View("CustomerForm", viewModel);
        }

    }
}