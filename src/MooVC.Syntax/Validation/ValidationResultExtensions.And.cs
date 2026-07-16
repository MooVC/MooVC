namespace MooVC.Syntax.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Provides extension methods for chaining validation operations on existing validation results.
    /// </summary>
    public static partial class ValidationResultExtensions
    {
        /// <summary>
        /// Validates a child object and appends its validation results to the existing result sequence.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="memberName">The member name used when creating the child validation context.</param>
        /// <param name="validatable">The child object to validate.</param>
        /// <returns>The combined validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.Include(memberName, preceding.Results, validatable);
        }

        /// <summary>
        /// Validates a child collection and appends their validation results to the existing result sequence.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="memberName">The member name used when creating each child validation context.</param>
        /// <param name="validatables">The child objects to validate.</param>
        /// <returns>The combined validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.Include(memberName, preceding.Results, validatables);
        }

        /// <summary>
        /// Validates a child object, applies a predicate, and appends the produced validation results.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="memberName">The member name used when creating the child validation context.</param>
        /// <param name="predicate">The predicate that determines whether the validated object satisfies a custom condition.</param>
        /// <param name="validatable">The child object to validate.</param>
        /// <returns>The combined validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            string memberName,
            Predicate<T> predicate,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.Include(memberName, predicate, preceding.Results, validatable);
        }

        /// <summary>
        /// Validates a child collection, applies a predicate to each element, and appends the produced validation results.
        /// </summary>
        /// <param name="preceding">The existing validation results and validation context.</param>
        /// <param name="memberName">The member name used when creating each child validation context.</param>
        /// <param name="predicate">The predicate that determines whether each validated object satisfies a custom condition.</param>
        /// <param name="validatables">The child objects to validate.</param>
        /// <returns>The combined validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.Include(memberName, predicate, preceding.Results, validatables);
        }
    }
}