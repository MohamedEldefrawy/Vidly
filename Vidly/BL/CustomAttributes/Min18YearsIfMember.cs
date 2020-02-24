using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.BL.Domain;

namespace Vidly.BL.CustomAttributes
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemmberShipTypeID == (byte)EnumMemberShipType.Unknown ||
                customer.MemmberShipTypeID == (byte)EnumMemberShipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.MemmberShipTypeID == (byte)EnumMemberShipType.Unknown)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - customer.BirthDate.Year;
            return (age >= 18) ?
                ValidationResult.Success :
                new ValidationResult("Customer should be at least 18 years old");
        }
    }
}