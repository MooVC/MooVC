namespace MooVC.Syntax.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public static partial class ValidationContextExtensions
    {
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(isSatisified, memberName, _ => true, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            IEnumerable<ValidationResult> results,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(isSatisified, memberName, _ => true, results, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(isSatisified, memberName, _ => true, validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            IEnumerable<ValidationResult> results,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            if (isSatisified)
            {
                return validationContext.Include(memberName, _ => true, results, validatables);
            }

            return (results, validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(condition, memberName, _ => true, Enumerable.Empty<ValidationResult>(), validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            IEnumerable<ValidationResult> results,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(condition, memberName, _ => true, results, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(condition, memberName, _ => true, Enumerable.Empty<ValidationResult>(), validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            IEnumerable<ValidationResult> results,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(condition, memberName, _ => true, results, validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            Predicate<T> predicate,
            T validatable)
            where T : IValidatableObject
        {
            if (isSatisified)
            {
                return validationContext.Include(memberName, predicate, Enumerable.Empty<ValidationResult>(), validatable);
            }

            return (Enumerable.Empty<ValidationResult>(), validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<ValidationResult> results,
            T validatable)
            where T : IValidatableObject
        {
            if (isSatisified)
            {
                return validationContext.Include(memberName, predicate, results, validatable);
            }

            return (results, validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            if (isSatisified)
            {
                return validationContext.Include(memberName, predicate, Enumerable.Empty<ValidationResult>(), validatables);
            }

            return (Enumerable.Empty<ValidationResult>(), validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<ValidationResult> results,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            if (isSatisified)
            {
                return validationContext.Include(memberName, predicate, results, validatables);
            }

            return (results, validationContext);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            Predicate<T> predicate,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(condition(), memberName, predicate, Enumerable.Empty<ValidationResult>(), validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<ValidationResult> results,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(condition(), memberName, predicate, results, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(condition(), memberName, predicate, Enumerable.Empty<ValidationResult>(), validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<ValidationResult> results,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(condition(), memberName, predicate, results, validatables);
        }
    }
}