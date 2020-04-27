using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
{
        // DateTime CurrentTime = DateTime.Now;
        // int CurrentYear = DateTime.Now.Year;
        // DateTime valueYear = (DateTime)value;

        if ((DateTime)value < DateTime.Now)
        {
            return new ValidationResult("Wedding Date must be in the future");

        }
            return ValidationResult.Success;
}    
}
}