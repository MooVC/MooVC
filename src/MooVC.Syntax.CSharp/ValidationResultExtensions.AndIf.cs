namespace MooVC.Syntax.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    internal static partial class ValidationResultExtensions
    {
        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            bool isSatisified,
            IValidatableObject validatable)
        {
            if (isSatisified)
            {
                return preceding.ValidationContext.Include(preceding.Results, validatable);
            }

            return preceding;
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            bool isSatisified,
            IEnumerable<IValidatableObject> validatables)
        {
            if (isSatisified)
            {
                return preceding.ValidationContext.Include(preceding.Results, validatables);
            }

            return preceding;
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            Func<bool> condition,
            IValidatableObject validatable)
        {
            return preceding.AndIf(condition(), validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            Func<bool> condition,
            IEnumerable<IValidatableObject> validatables)
        {
            return preceding.AndIf(condition(), validatables);
        }
    }
}