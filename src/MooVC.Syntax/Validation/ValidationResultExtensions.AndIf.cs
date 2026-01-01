namespace MooVC.Syntax.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public static partial class ValidationResultExtensions
    {
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            bool isSatisified,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.AndIf(isSatisified, memberName, _ => true, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            bool isSatisified,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return preceding.AndIf(isSatisified, memberName, _ => true, validatables);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            Func<bool> condition,
            string memberName,
            T validatable)
            where T : IValidatableObject
        {
            return preceding.AndIf(condition, memberName, _ => true, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf<T>(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            Func<bool> condition,
            string memberName,
            IEnumerable<T> validatables)
            where T : IValidatableObject
        {
            return preceding.AndIf(condition, memberName, _ => true, validatables);
        }

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