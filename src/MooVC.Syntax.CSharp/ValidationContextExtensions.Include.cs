namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using MooVC.Syntax.CSharp.Members;
    using static MooVC.Syntax.CSharp.ValidationContextExtensions_Resources;

    internal static partial class ValidationContextExtensions
    {
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, _ => true, Enumerable.Empty<ValidationResult>(), validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            IEnumerable<ValidationResult> results,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, _ => true, results, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, _ => true, validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            IEnumerable<ValidationResult> results,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, _ => true, results, validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            Predicate<T> predicate,
            T validatable)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, predicate, Enumerable.Empty<ValidationResult>(), validatable);
        }

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

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) Include<T>(
            this ValidationContext validationContext,
            string memberName,
            Predicate<T> predicate,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return validationContext.Include(memberName, predicate, Enumerable.Empty<ValidationResult>(), validatables);
        }

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