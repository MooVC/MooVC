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
            string memberName,
            IValidatableObject validatable)
        {
            if (isSatisified)
            {
                return preceding.ValidationContext.Include(memberName, preceding.Results, validatable);
            }

            return preceding;
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            bool isSatisified,
            string memberName,
            IEnumerable<IValidatableObject> validatables)
        {
            if (isSatisified)
            {
                return preceding.ValidationContext.Include(memberName, preceding.Results, validatables);
            }

            return preceding;
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            Func<bool> condition,
            string memberName,
            IValidatableObject validatable)
        {
            return preceding.AndIf(condition(), memberName, validatable);
        }

        public static (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) AndIf(
            this (IEnumerable<ValidationResult> Results, ValidationContext ValidationContext) preceding,
            Func<bool> condition,
            string memberName,
            IEnumerable<IValidatableObject> validatables)
        {
            return preceding.AndIf(condition(), memberName, validatables);
        }
    }
}