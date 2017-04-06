using System;
using System.ComponentModel.DataAnnotations;
using WeBStore.ViewModel;
namespace WeBStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }

        [Min18yearsIfAMember]
        [Display(Name = "Data of Birth")]
        public DateTime? DateOfBirth { get; set; }

        //adding navigation properties  

        public MembershipType MembershipType { get; set; }

        //if type of the property is "Byte" then its implicitly required


        [Display(Name = "Membership Type")]
        public byte MembershipTypeID { get; set; }
    }
}