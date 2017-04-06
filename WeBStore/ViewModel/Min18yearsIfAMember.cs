using System;
using System.ComponentModel.DataAnnotations;
using WeBStore.Models;

namespace WeBStore.ViewModel
{
    public class Min18yearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeID == MembershipType.Unknown ||
                customer.MembershipTypeID == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.DateOfBirth == null)
            {
                return new ValidationResult("Date of Birth is Required.");
            }

            var age = DateTime.Now.Year - customer.DateOfBirth.Value.Year;

            return (age > 18) ? ValidationResult.Success : new ValidationResult("Customer's Age should be atleast 18 to get membership");
        }
    }
}