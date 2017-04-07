using System;
using System.ComponentModel.DataAnnotations;

namespace WeBStore.Dto
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }

        // [Min18yearsIfAMember]
        public DateTime? DateOfBirth { get; set; }

        //if type of the property is "Byte" then its implicitly required


        [Display(Name = "Membership Type")]
        public byte MembershipTypeID { get; set; }
    }
}