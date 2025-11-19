namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    internal static partial class ValidationContextExtensions
    {
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            bool isSatisified,
            IValidatableObject validatable)
        {
            if (isSatisified)
            {
                return validationContext.Include(Enumerable.Empty<ValidationResult>(), validatable);
            }

            return (Enumerable.Empty<ValidationResult>(), validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            bool isSatisified,
            IEnumerable<ValidationResult> results,
            IValidatableObject validatable)
        {
            if (isSatisified)
            {
                return validationContext.Include(results, validatable);
            }

            return (results, validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            bool isSatisified,
            IEnumerable<IValidatableObject> validatables)
        {
            if (isSatisified)
            {
                return validationContext.Include(Enumerable.Empty<ValidationResult>(), validatables);
            }

            return (Enumerable.Empty<ValidationResult>(), validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            bool isSatisified,
            IEnumerable<ValidationResult> results,
            IEnumerable<IValidatableObject> validatables)
        {
            if (isSatisified)
            {
                return validationContext.Include(results, validatables);
            }

            return (results, validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            Func<bool> condition,
            IValidatableObject validatable)
        {
            return validationContext.IncludeIf(condition(), Enumerable.Empty<ValidationResult>(), validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            Func<bool> condition,
            IEnumerable<ValidationResult> results,
            IValidatableObject validatable)
        {
            return validationContext.IncludeIf(condition(), results, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            Func<bool> condition,
            IEnumerable<IValidatableObject> validatables)
        {
            return validationContext.IncludeIf(condition(), Enumerable.Empty<ValidationResult>(), validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            Func<bool> condition,
            IEnumerable<ValidationResult> results,
            IEnumerable<IValidatableObject> validatables)
        {
            return validationContext.IncludeIf(condition(), results, validatables);
        }
    }
}