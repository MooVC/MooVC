namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.ValidationContextExtensions_Resources;

    internal static partial class ValidationContextExtensions
    {
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include(
            this ValidationContext validationContext,
            IValidatableObject validatable)
        {
            return validationContext.Include(validatable, Enumerable.Empty<ValidationResult>());
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include(
            this ValidationContext validationContext,
            IEnumerable<ValidationResult> results,
            IValidatableObject validatable)
        {
            _ = Guard.Against.Null(results, message: IncludeResultsRequired);
            _ = Guard.Against.Null(validatable, message: IncludeValidatableRequired);
            _ = Guard.Against.Null(validationContext, message: IncludeValidationContextRequired);

            return validationContext.Validate(validatable, results);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include(
            this ValidationContext validationContext,
            IEnumerable<IValidatableObject> validatables)
        {
            return validationContext.Include(Enumerable.Empty<ValidationResult>(), validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include(
            this ValidationContext validationContext,
            IEnumerable<ValidationResult> results,
            IEnumerable<IValidatableObject> validatables)
        {
            _ = Guard.Against.Null(results, message: IncludeResultsRequired);
            _ = Guard.Against.Null(validatables, message: IncludeValidatablesRequired);
            _ = Guard.Against.Null(validationContext, message: IncludeValidationContextRequired);

            foreach (IValidatableObject validatable in validatables)
            {
                results = validationContext
                    .Validate(results, validatable)
                    .Results;
            }

            return (results, validationContext);
        }

        private static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Validate(
            this ValidationContext validationContext,
            IEnumerable<ValidationResult> results,
            IValidatableObject validatable)
        {
            IEnumerable<ValidationResult> inclusions = validatable.Validate(validationContext);

            return (results.Concat(inclusions), validationContext);
        }
    }
}