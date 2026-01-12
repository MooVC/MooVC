namespace MooVC.Syntax.Attributes.Solution
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Fluentify;
    using Monify;
    using static MooVC.Syntax.Attributes.Solution.Project_Resources;

    /// <summary>
    /// Represents a MSBuild solution attribute project.
    /// </summary>
    public sealed partial class Project
    {
        /// <summary>
        /// Represents a file system path that is relative to a base directory, excluding absolute or root-based paths.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class RelativePath
            : IValidatableObject
        {
            /// <summary>
            /// Represents an unspecified or empty relative path.
            /// </summary>
            public static readonly RelativePath Unspecified = string.Empty;

            private static readonly Regex rule = new Regex(
                @"^(?![\\/])(?![A-Za-z]:)(?!\\\\)(?:(?:[^<>:""|?*\x00-\x1F\\/]+[\\/])*[^<>:""|?*\x00-\x1F\\/]+\.[^<>:""|?*\x00-\x1F\\/\.]+)$",
                RegexOptions.Compiled | RegexOptions.CultureInvariant);

            /// <summary>
            /// Gets a value indicating whether the current instance represents an unspecified value.
            /// </summary>
            /// <value>
            /// A value indicating whether the current instance represents an unspecified value.
            /// </value>
            public bool IsUnspecified => this == Unspecified;

            /// <summary>
            /// Validates the current object and returns a collection of validation results that describe any validation errors.
            /// </summary>
            /// <param name="validationContext">
            /// The context information about the object being validated. Provides services and information that may be used during validation.
            /// </param>
            /// <returns>
            /// A collection of <see cref="ValidationResult"/> objects that describe any validation errors.
            /// The collection is empty if the object is valid.
            /// </returns>
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (IsUnspecified)
                {
                    yield break;
                }

                if (_value is null || !rule.IsMatch(_value))
                {
                    yield return new ValidationResult(
                        RelativePathValidateValueInvalid.Format(nameof(Path), nameof(Project), _value),
                        new[] { nameof(RelativePath) });
                }
            }
        }
    }
}