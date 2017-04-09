using System.Collections.Generic;

namespace WeBStore.Dto
{
    public class NewRentalDto
    {
        public int CustomerID { get; set; }

        public List<int> MovieIds { get; set; }
    }
}