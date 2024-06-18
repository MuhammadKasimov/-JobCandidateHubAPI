using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobCandidateHubAPI.UnitTest.Extensions
{
    public static class ValidationHelper
    {
        public static bool ValidateObject(object obj)
        {
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, context, results, validateAllProperties: true);
        }

        public static bool ValidateProperty(object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property == null) throw new ArgumentException($"Property '{propertyName}' not found");

            var value = property.GetValue(obj);
            var context = new ValidationContext(obj) { MemberName = propertyName };
            var results = new List<ValidationResult>();
            return Validator.TryValidateProperty(value, context, results);
        }
    }
}
