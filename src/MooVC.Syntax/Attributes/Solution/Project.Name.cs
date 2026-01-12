namespace MooVC.Syntax.Attributes.Solution
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Fluentify;
    using Monify;
    using static MooVC.Syntax.Attributes.Solution.Project_Resources;

    /// <summary>
    /// Represents a MSBuild solution attribute project.
    /// </summary>
    public partial class Project
    {
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Name
            : IValidatableObject
        {
            public static readonly Name Unnamed = string.Empty;

            private static readonly Regex rule = new Regex(
                @"^(?!\s*$)(?!.*[\uFFFE\uFFFF])[^\x00-\x08\x0B\x0C\x0E-\x1F""<> &]*$",
                RegexOptions.Compiled | RegexOptions.CultureInvariant);

            public bool IsUnnamed => this == Unnamed;

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (IsUnnamed)
                {
                    yield break;
                }

                if (_value is null || !rule.IsMatch(_value))
                {
                    yield return new ValidationResult(NameValidateValueInvalid.Format(nameof(DisplayName), nameof(Project), _value), new[] { nameof(Name) });
                }
            }
        }
    }
}