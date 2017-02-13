using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZenithDataLib.Validation
{
     class EndDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (Models.Event)validationContext.ObjectInstance;
            DateTime Start = Convert.ToDateTime(model.Start);
            DateTime End = Convert.ToDateTime(value);
            int day1 = Start.Day;
            int day2 = End.Day;

            if (Start.Year == End.Year) {
                if (day1 + 1 == day2) {
                    return ValidationResult.Success;
                } else if (day1 > day2) {
                    return new ValidationResult("Start date must be before end date");
                } else if (day1 == day2) {
                    if(Start.Hour > End.Hour)
                    {
                        return new ValidationResult("Start time must be before end time");
                    } else {
                        return ValidationResult.Success;
                    }
                } else {
                    return new ValidationResult("Event can't last more than a day");
                }
            } else {
                return new ValidationResult("Event can't last more than a day");
            }
        }
    }
}