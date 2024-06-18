using FluentAssertions.Primitives;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace JobCandidateHubAPI.UnitTest.Extensions
{
    public static class AssertionExtensions
    {
        public static AndConstraint<ObjectAssertions> BeValidForProperty(this ObjectAssertions assertions, string propertyName)
        {
            var obj = assertions.Subject;

            bool isValid = ValidationHelper.ValidateProperty(obj, propertyName);
            isValid.Should().BeTrue($"property '{propertyName}' should be valid");

            return new AndConstraint<ObjectAssertions>(assertions);
        }
    }
}
