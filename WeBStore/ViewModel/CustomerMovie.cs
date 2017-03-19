using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeBStore.Models;

namespace WeBStore.ViewModel
{
    public class CustomerMovie
    {
        public Movie Movie { get; set; }
        public List<Customer> CustomerList { get; set; }
    }
}