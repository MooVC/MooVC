namespace MooVC.Syntax.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Validation.ValidationContextExtensions_Resources;

    /// <summary>
    /// Provides extension methods for validating child objects from a <see cref="ValidationContext" />.
    /// </summary>
    public static partial class ValidationContextExtensions
    {
        /// <summary>
        /// Validates a child object and returns its validation results.
        /// </summary>
        /// <param name="validationContext">The parent validation context.</param>
        /// <param name="memberName">The member name assigned to the child validation context.</param>
        /// <param name="validatable">The child object to validate.</param>
        /// <returns>The validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, _ => true, Enumerable.Empty<ValidationResult>(), validatable);
        }

        /// <summary>
        /// Validates a child object and appends the results to an existing result sequence.
        /// </summary>
        /// <param name="validationContext">The parent validation context.</param>
        /// <param name="memberName">The member name assigned to the child validation context.</param>
        /// <param name="results">The existing validation results to append to.</param>
        /// <param name="validatable">The child object to validate.</param>
        /// <returns>The validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            IEnumerable<ValidationResult> results,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, _ => true, results, validatable);
        }

        /// <summary>
        /// Validates a child collection and returns the combined validation results.
        /// </summary>
        /// <param name="validationContext">The parent validation context.</param>
        /// <param name="memberName">The member name assigned to each child validation context.</param>
        /// <param name="validatables">The child objects to validate.</param>
        /// <returns>The validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, _ => true, validatables);
        }

        /// <summary>
        /// Validates a child collection and appends the results to an existing result sequence.
        /// </summary>
        /// <param name="validationContext">The parent validation context.</param>
        /// <param name="memberName">The member name assigned to each child validation context.</param>
        /// <param name="results">The existing validation results to append to.</param>
        /// <param name="validatables">The child objects to validate.</param>
        /// <returns>The validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            IEnumerable<ValidationResult> results,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, _ => true, results, validatables);
        }

        /// <summary>
        /// Validates a child object, then applies a predicate to the validated object.
        /// </summary>
        /// <param name="validationContext">The parent validation context.</param>
        /// <param name="memberName">The member name assigned to the child validation context.</param>
        /// <param name="predicate">The predicate that determines whether the object satisfies an additional condition.</param>
        /// <param name="validatable">The child object to validate.</param>
        /// <returns>The validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            Predicate<T> predicate,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, predicate, Enumerable.Empty<ValidationResult>(), validatable);
        }

        /// <summary>
        /// Validates a child object, applies a predicate, and appends the results to an existing sequence.
        /// </summary>
        /// <param name="validationContext">The parent validation context.</param>
        /// <param name="memberName">The member name assigned to the child validation context.</param>
        /// <param name="predicate">The predicate that determines whether the object satisfies an additional condition.</param>
        /// <param name="results">The existing validation results to append to.</param>
        /// <param name="validatable">The child object to validate.</param>
        /// <returns>The validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<ValidationResult> results,
            T validatable)
            where T : IValidatableObject
        {
            _ = Guard.Against.Null(memberName, message: IncludeMemberNameRequired.Format(typeof(T)));
            _ = Guard.Against.Null(predicate, message: IncludePredicateRequired.Format(memberName, typeof(T)));
            _ = Guard.Against.Null(results, message: IncludeResultsRequired.Format(memberName, typeof(T)));
            _ = Guard.Against.Null(validatable, message: IncludeValidatableRequired.Format(memberName, typeof(T)));
            _ = Guard.Against.Null(validationContext, message: IncludeValidationContextRequired.Format(memberName, typeof(T)));

            return validationContext.Validate(memberName, predicate, results, validatable);
        }

        /// <summary>
        /// Validates a child collection, then applies a predicate to each validated object.
        /// </summary>
        /// <param name="validationContext">The parent validation context.</param>
        /// <param name="memberName">The member name assigned to each child validation context.</param>
        /// <param name="predicate">The predicate that determines whether each object satisfies an additional condition.</param>
        /// <param name="validatables">The child objects to validate.</param>
        /// <returns>The validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, predicate, Enumerable.Empty<ValidationResult>(), validatables);
        }

        /// <summary>
        /// Validates a child collection, applies a predicate to each element, and appends the results to an existing sequence.
        /// </summary>
        /// <param name="validationContext">The parent validation context.</param>
        /// <param name="memberName">The member name assigned to each child validation context.</param>
        /// <param name="predicate">The predicate that determines whether each object satisfies an additional condition.</param>
        /// <param name="results">The existing validation results to append to.</param>
        /// <param name="validatables">The child objects to validate.</param>
        /// <returns>The validation results and original validation context.</returns>
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<ValidationResult> results,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            _ = Guard.Against.Null(memberName, message: IncludeMemberNameRequired.Format(typeof(T)));
            _ = Guard.Against.Null(predicate, message: IncludePredicateRequired.Format(memberName, typeof(T)));
            _ = Guard.Against.Null(results, message: IncludeResultsRequired.Format(memberName, typeof(T)));
            _ = Guard.Against.Null(validatables, message: IncludeValidatablesRequired.Format(memberName, typeof(T)));
            _ = Guard.Against.Null(validationContext, message: IncludeValidationContextRequired.Format(memberName, typeof(T)));

            foreach (T validatable in validatables)
            {
                results = validationContext
                    .Validate(memberName, predicate, results, validatable)
                    .Results;
            }

            return (results, validationContext);
        }

        private static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Validate<T>(
            this ValidationContext validationContext,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<ValidationResult> results,
            T validatable)
            where T : IValidatableObject
        {
            var childContext = new ValidationContext(validatable, validationContext, validationContext.Items)
            {
                MemberName = memberName,
            };

            IEnumerable<ValidationResult> inclusions = validatable.Validate(childContext);

            if (!predicate(validatable))
            {
                inclusions = inclusions.Append(new ValidationResult(
                    ValidateConditionNotSatisified.Format(memberName, typeof(T)),
                    new[] { memberName }));
            }

            return (results.Concat(inclusions), validationContext);
        }
    }
}