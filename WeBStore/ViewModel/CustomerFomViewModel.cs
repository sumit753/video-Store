using System.Collections.Generic;
using WeBStore.Models;

namespace WeBStore.ViewModel
{
    public class CustomerFomViewModel
    {   //IEnumerable is similar to list but it does'nt provide methods to add,delete,InsertAtIndex etc

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}