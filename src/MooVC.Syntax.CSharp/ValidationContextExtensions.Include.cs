namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.ValidationContextExtensions_Resources;

    internal static partial class ValidationContextExtensions
    {
        public static IEnumerable<ValidationResult> Include(this ValidationContext validationContext, IValidatableObject validatable)
        {
            return validationContext.Include(validatable, Enumerable.Empty<ValidationResult>());
        }

        public static IEnumerable<ValidationResult> Include(
            this ValidationContext validationContext,
            IValidatableObject validatable,
            IEnumerable<ValidationResult> results)
        {
            _ = Guard.Against.Null(validationContext, message: IncludeValidationContextRequired);
            _ = Guard.Against.Null(validatable, message: IncludeValidatableRequired);
            _ = Guard.Against.Null(results, message: IncludeResultsRequired);

            return validationContext.Validate(validatable, results);
        }

        public static IEnumerable<ValidationResult> Include(this ValidationContext validationContext, IEnumerable<IValidatableObject> validatables)
        {
            return validationContext.Include(validatables, Enumerable.Empty<ValidationResult>());
        }

        public static IEnumerable<ValidationResult> Include(
            this ValidationContext validationContext,
            IEnumerable<IValidatableObject> validatables,
            IEnumerable<ValidationResult> results)
        {
            _ = Guard.Against.Null(validationContext, message: IncludeValidationContextRequired);
            _ = Guard.Against.Null(validatables, message: IncludeValidatablesRequired);
            _ = Guard.Against.Null(results, message: IncludeResultsRequired);

            foreach (IValidatableObject validatable in validatables)
            {
                results = validationContext.Validate(validatable, results);
            }

            return results;
        }

        private static IEnumerable<ValidationResult> Validate(
            this ValidationContext validationContext,
            IValidatableObject validatable,
            IEnumerable<ValidationResult> results)
        {
            IEnumerable<ValidationResult> inclusions = validatable.Validate(validationContext);

            return results.Concat(inclusions);
        }
    }
}