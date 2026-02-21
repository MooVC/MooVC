namespace MooVC.Syntax.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a validation helper validation result extensions.
    /// </summary>
    public static partial class ValidationResultExtensions
    {
        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.Include(memberName, preceding.Results, validatable);
        }

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.Include(memberName, preceding.Results, validatables);
        }

        /// <summary>
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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
        /// Performs the static operation for the validation helper.
        /// </summary>
        /// <param name="Results">The results.</param>
        /// <param name="ValidationContext">The validation context.</param>
        /// <returns>The public.</returns>
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