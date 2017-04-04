using System;
using System.ComponentModel.DataAnnotations;

namespace WeBStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool isSubscribedToNewsletter { get; set; }
        public DateTime? DateOfBirth { get; set; }

        //adding navigation properties  
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeID { get; set; }
    }
}