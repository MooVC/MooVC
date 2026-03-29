namespace MooVC.Syntax.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Provides extension methods for conditionally validating child objects from a <see cref="ValidationContext" />.
    /// </summary>
    public static partial class ValidationContextExtensions
    {
        /// <summary>
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="isSatisified">The isSatisified parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="validatable">The validatable parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="isSatisified">The isSatisified parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="results">The results parameter.</param>
        /// <param name="validatable">The validatable parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="isSatisified">The isSatisified parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="validatables">The validatables parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="isSatisified">The isSatisified parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="results">The results parameter.</param>
        /// <param name="validatables">The validatables parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="condition">The condition parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="validatable">The validatable parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="condition">The condition parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="results">The results parameter.</param>
        /// <param name="validatable">The validatable parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="condition">The condition parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="validatables">The validatables parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="condition">The condition parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="results">The results parameter.</param>
        /// <param name="validatables">The validatables parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="isSatisified">The isSatisified parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="predicate">The predicate parameter.</param>
        /// <param name="validatable">The validatable parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="isSatisified">The isSatisified parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="predicate">The predicate parameter.</param>
        /// <param name="results">The results parameter.</param>
        /// <param name="validatable">The validatable parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="isSatisified">The isSatisified parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="predicate">The predicate parameter.</param>
        /// <param name="validatables">The validatables parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="isSatisified">The isSatisified parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="predicate">The predicate parameter.</param>
        /// <param name="results">The results parameter.</param>
        /// <param name="validatables">The validatables parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="condition">The condition parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="predicate">The predicate parameter.</param>
        /// <param name="validatable">The validatable parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="condition">The condition parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="predicate">The predicate parameter.</param>
        /// <param name="results">The results parameter.</param>
        /// <param name="validatable">The validatable parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="condition">The condition parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="predicate">The predicate parameter.</param>
        /// <param name="validatables">The validatables parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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
        /// Conditionally validates child value(s) and appends any produced validation results.
        /// </summary>
        /// <param name="validationContext">The validationContext parameter.</param>
        /// <param name="condition">The condition parameter.</param>
        /// <param name="memberName">The memberName parameter.</param>
        /// <param name="predicate">The predicate parameter.</param>
        /// <param name="results">The results parameter.</param>
        /// <param name="validatables">The validatables parameter.</param>
        /// <returns>The validation results and validation context.</returns>
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