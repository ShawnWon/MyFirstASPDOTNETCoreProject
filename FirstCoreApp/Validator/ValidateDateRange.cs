using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Validator
{
    public class ValidateDateRange: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value) > Convert.ToDateTime("02/25/2020") && Convert.ToDateTime(value) < Convert.ToDateTime("02/27/2020"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date is out of range");
            }
            
        }
    }
}
