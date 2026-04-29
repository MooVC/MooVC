namespace MooVC.Syntax.Solution
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using Fluentify;
    using Monify;
    using static MooVC.Syntax.Solution.Project_Resources;

    /// <summary>
    /// Represents a MSBuild solution attribute project.
    /// </summary>
    public partial class Project
    {
        /// <summary>
        /// Represents the display name of a solution project entry.
        /// </summary>
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Name
            : IValidatableObject
        {
            public static readonly Name Unnamed = string.Empty;

            private static readonly Regex _rule = new Regex(
                @"^(?![ .])(?!.*[ .]$)[^\\/:*?""<>|]+$",
                RegexOptions.Compiled | RegexOptions.CultureInvariant);

            public bool IsUnnamed => this == Unnamed;

            /// <summary>
            /// Returns the name of the project verbatim.
            /// </summary>
            /// <returns>The name of the project verbatim.</returns>
            public override string ToString()
            {
                return _value;
            }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (IsUnnamed)
                {
                    yield break;
                }

                if (_value is null || !_rule.IsMatch(_value))
                {
                    yield return new ValidationResult(
                        NameValidateValueInvalid.Format(nameof(DisplayName), nameof(Project), _value),
                        new[] { nameof(Name) });
                }
            }

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Name)} {{ {_value} }}";
            }
        }
    }
}