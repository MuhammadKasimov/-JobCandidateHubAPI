using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateHubAPI.Service.Validations.Attributes
{
    public class LinkedIn : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;
            else if (value is string url)
                if (url.StartsWith("https://www.linkedin.com/") || url.StartsWith("https://linkedin.com/"))
                    return ValidationResult.Success;

            return new ValidationResult("Invalid LinkedIn url");
        }
    }
}
