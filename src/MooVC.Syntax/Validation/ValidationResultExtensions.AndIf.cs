namespace MooVC.Syntax.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Provides extension methods for conditionally chaining validation operations on existing validation results.
    /// </summary>
    public static partial class ValidationResultExtensions
    {
        /// <summary>
        /// Conditionally validates a child object and appends results when the supplied flag is satisfied.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="isSatisified">A value indicating whether validation should run.</param>
        /// <param name="memberName">The member name used when creating the child validation context.</param>
        /// <param name="validatable">The child object to validate.</param>
        /// <returns>The updated validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            bool isSatisified,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.AndIf(isSatisified, memberName, _ => true, validatable);
        }

        /// <summary>
        /// Conditionally validates child objects and appends results when the supplied flag is satisfied.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="isSatisified">A value indicating whether validation should run.</param>
        /// <param name="memberName">The member name used when creating each child validation context.</param>
        /// <param name="validatables">The child objects to validate.</param>
        /// <returns>The updated validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            bool isSatisified,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return preceding.AndIf(isSatisified, memberName, _ => true, validatables);
        }

        /// <summary>
        /// Conditionally validates a child object and appends results when the supplied delegate evaluates to <see langword="true" />.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="condition">A delegate that determines whether validation should run.</param>
        /// <param name="memberName">The member name used when creating the child validation context.</param>
        /// <param name="validatable">The child object to validate.</param>
        /// <returns>The updated validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            Func<bool> condition,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.AndIf(condition, memberName, _ => true, validatable);
        }

        /// <summary>
        /// Conditionally validates child objects and appends results when the supplied delegate evaluates to <see langword="true" />.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="condition">A delegate that determines whether validation should run.</param>
        /// <param name="memberName">The member name used when creating each child validation context.</param>
        /// <param name="validatables">The child objects to validate.</param>
        /// <returns>The updated validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            Func<bool> condition,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return preceding.AndIf(condition, memberName, _ => true, validatables);
        }

        /// <summary>
        /// Conditionally validates a child object, applies a predicate, and appends the produced results.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="isSatisified">A value indicating whether validation should run.</param>
        /// <param name="memberName">The member name used when creating the child validation context.</param>
        /// <param name="predicate">The predicate used to validate a post-validation condition.</param>
        /// <param name="validatable">The child object to validate.</param>
        /// <returns>The updated validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            bool isSatisified,
            string memberName,
            Predicate<T> predicate,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.IncludeIf(isSatisified, memberName, predicate, preceding.Results, validatable);
        }

        /// <summary>
        /// Conditionally validates child objects, applies a predicate to each, and appends the produced results.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="isSatisified">A value indicating whether validation should run.</param>
        /// <param name="memberName">The member name used when creating each child validation context.</param>
        /// <param name="predicate">The predicate used to validate a post-validation condition.</param>
        /// <param name="validatables">The child objects to validate.</param>
        /// <returns>The updated validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            bool isSatisified,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.IncludeIf(isSatisified, memberName, predicate, preceding.Results, validatables);
        }

        /// <summary>
        /// Conditionally validates a child object, applies a predicate, and appends the produced results.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="condition">A delegate that determines whether validation should run.</param>
        /// <param name="memberName">The member name used when creating the child validation context.</param>
        /// <param name="predicate">The predicate used to validate a post-validation condition.</param>
        /// <param name="validatable">The child object to validate.</param>
        /// <returns>The updated validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            Func<bool> condition,
            string memberName,
            Predicate<T> predicate,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.IncludeIf(condition, memberName, predicate, preceding.Results, validatable);
        }

        /// <summary>
        /// Conditionally validates child objects, applies a predicate to each, and appends the produced results.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="condition">A delegate that determines whether validation should run.</param>
        /// <param name="memberName">The member name used when creating each child validation context.</param>
        /// <param name="predicate">The predicate used to validate a post-validation condition.</param>
        /// <param name="validatables">The child objects to validate.</param>
        /// <returns>The updated validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            Func<bool> condition,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.IncludeIf(condition, memberName, predicate, preceding.Results, validatables);
        }
    }
}