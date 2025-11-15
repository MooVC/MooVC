namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    internal static partial class ValidationResultExtensions
    {
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            IValidatableObject validatable)
        {
            return preceding.ValidationContext.Include(preceding.Results, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            IEnumerable<IValidatableObject> validatables)
        {
            return preceding.ValidationContext.Include(preceding.Results, validatables);
        }
    }
}