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
            string memberName,
            IValidatableObject validatable)
        {
            if (isSatisified)
            {
                return validationContext.Include(memberName, Enumerable.Empty<ValidationResult>(), validatable);
            }

            return (Enumerable.Empty<ValidationResult>(), validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            IEnumerable<ValidationResult> results,
            IValidatableObject validatable)
        {
            if (isSatisified)
            {
                return validationContext.Include(memberName, results, validatable);
            }

            return (results, validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            IEnumerable<IValidatableObject> validatables)
        {
            if (isSatisified)
            {
                return validationContext.Include(memberName, Enumerable.Empty<ValidationResult>(), validatables);
            }

            return (Enumerable.Empty<ValidationResult>(), validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            IEnumerable<ValidationResult> results,
            IEnumerable<IValidatableObject> validatables)
        {
            if (isSatisified)
            {
                return validationContext.Include(memberName, results, validatables);
            }

            return (results, validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            IValidatableObject validatable)
        {
            return validationContext.IncludeIf(condition(), memberName, Enumerable.Empty<ValidationResult>(), validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            IEnumerable<ValidationResult> results,
            IValidatableObject validatable)
        {
            return validationContext.IncludeIf(condition(), memberName, results, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            IEnumerable<IValidatableObject> validatables)
        {
            return validationContext.IncludeIf(condition(), memberName, Enumerable.Empty<ValidationResult>(), validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            IEnumerable<ValidationResult> results,
            IEnumerable<IValidatableObject> validatables)
        {
            return validationContext.IncludeIf(condition(), memberName, results, validatables);
        }
    }
}