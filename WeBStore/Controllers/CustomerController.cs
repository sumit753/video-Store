using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeBStore.Models;

namespace WeBStore.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int Id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
                            {
                               new Customer {Id=1,Name="Sumit" },
                               new Customer { Id=2,Name="Amit"},
                               new Customer {Id=3,Name="James" },
                               new Customer {Id=4,Name="Mohan" },
                               new Customer {Id=5,Name="Tika" },
                                new Customer {Id=6,Name="Saxena" },
                                new Customer {Id=7,Name="Vibhuti" }

                                 };
        }
    }
}