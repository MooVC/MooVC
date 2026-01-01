namespace MooVC.Syntax.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public static partial class ValidationResultExtensions
    {
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.Include(memberName, preceding.Results, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.Include(memberName, preceding.Results, validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) And<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            string memberName,
            Predicate<T> predicate,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.ValidationContext.Include(memberName, predicate, preceding.Results, validatable);
        }

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