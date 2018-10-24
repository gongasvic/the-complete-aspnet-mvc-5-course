using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MinAgeToSubscribe : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var daysInYear = 365.2422;
            var minAge = 18;
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.Free)
                return ValidationResult.Success;
            if (customer.Dob == null)
                return new ValidationResult("Birthdate must be provided.");
            TimeSpan age = DateTime.Today.Date - customer.Dob.Value.Date;
            if (age.TotalDays / daysInYear < minAge)
                return new ValidationResult("The minimum Age for subscriptions is " + minAge);

            return ValidationResult.Success;

        }
    }
}