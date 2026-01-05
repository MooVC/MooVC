namespace MooVC.Syntax.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Represents a validation helper validation context extensions.
    /// </summary>
    public static partial class ValidationContextExtensions
    {
        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(isSatisified, memberName, _ => true, validatable);
        }

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            bool isSatisified,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(isSatisified, memberName, _ => true, validatables);
        }

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(condition, memberName, _ => true, Enumerable.Empty<ValidationResult>(), validatable);
        }

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) IncludeIf<T>(
            this ValidationContext validationContext,
            Func<bool> condition,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.IncludeIf(condition, memberName, _ => true, Enumerable.Empty<ValidationResult>(), validatables);
        }

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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