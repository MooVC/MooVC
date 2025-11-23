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
            string memberName,
            IValidatableObject validatable)
        {
            return validationContext.Include(memberName, Enumerable.Empty<ValidationResult>(), validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include(
            this ValidationContext validationContext,
            string memberName,
            IEnumerable<ValidationResult> results,
            IValidatableObject validatable)
        {
            _ = Guard.Against.Null(memberName, message: IncludeMemberNameRequired);
            _ = Guard.Against.Null(results, message: IncludeResultsRequired);
            _ = Guard.Against.Null(validatable, message: IncludeValidatableRequired);
            _ = Guard.Against.Null(validationContext, message: IncludeValidationContextRequired);

            return validationContext.Validate(memberName, results, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include(
            this ValidationContext validationContext,
            string memberName,
            IEnumerable<IValidatableObject> validatables)
        {
            return validationContext.Include(memberName, Enumerable.Empty<ValidationResult>(), validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include(
            this ValidationContext validationContext,
            string memberName,
            IEnumerable<ValidationResult> results,
            IEnumerable<IValidatableObject> validatables)
        {
            _ = Guard.Against.Null(results, message: IncludeResultsRequired);
            _ = Guard.Against.Null(validatables, message: IncludeValidatablesRequired);
            _ = Guard.Against.Null(validationContext, message: IncludeValidationContextRequired);

            foreach (IValidatableObject validatable in validatables)
            {
                results = validationContext
                    .Validate(memberName, results, validatable)
                    .Results;
            }

            return (results, validationContext);
        }

        private static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Validate(
            this ValidationContext validationContext,
            string memberName,
            IEnumerable<ValidationResult> results,
            IValidatableObject validatable)
        {
            var childContext = new ValidationContext(validatable, validationContext, validationContext.Items)
            {
                MemberName = memberName,
            };

            IEnumerable<ValidationResult> inclusions = validatable.Validate(childContext);

            return (results.Concat(inclusions), validationContext);
        }
    }
}