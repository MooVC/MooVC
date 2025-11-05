namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    internal static partial class ValidationResultExtensions
    {
        public static IEnumerable<ValidationResult> And(
            this IEnumerable<ValidationResult> results,
            ValidationContext validationContext,
            IValidatableObject validatable)
        {
            return validationContext.Include(validatable, results);
        }

        public static IEnumerable<ValidationResult> And(
            this IEnumerable<ValidationResult> results,
            ValidationContext validationContext,
            IEnumerable<IValidatableObject> validatables)
        {
            return validationContext.Include(validatables, results);
        }
    }
}