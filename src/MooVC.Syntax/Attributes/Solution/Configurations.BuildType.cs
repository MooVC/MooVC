namespace MooVC.Syntax.Attributes.Solution
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using Fluentify;
    using Monify;
    using static MooVC.Syntax.Attributes.Solution.Configurations_Resources;

    /// <summary>
    /// Provides configuration-related types and functionality for managing build settings and validation within the
    /// application.
    /// </summary>
    public partial class Configurations
    {
        /// <summary>
        /// Represents a build configuration type, such as Debug or Release, used to distinguish different build
        /// variants in a solution.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class BuildType
            : IValidatableObject
        {
            /// <summary>
            /// Represents a build type with no name specified.
            /// </summary>
            public static readonly BuildType Unnamed = string.Empty;

            /// <summary>
            /// Represents the build type for debug configurations.
            /// </summary>
            public static readonly BuildType Debug = "Debug";

            /// <summary>
            /// Represents the build type for release builds.
            /// </summary>
            public static readonly BuildType Release = "Release";

            private static readonly Regex rule = new Regex(@"^(?!\s)[^\x00-\x1F\x7F""<>]{1,64}(?<!\s)$", RegexOptions.Compiled);

            /// <summary>
            /// Gets a value indicating whether the current instance represents an unnamed value.
            /// </summary>
            /// <value>
            /// A value indicating whether the current instance represents an unnamed value.
            /// </value>
            public bool IsUnnamed => this == Unnamed;

            /// <summary>
            /// Performs the to fragments operation for the MSBuild solution attribute.
            /// </summary>
            /// <returns>The immutable array x element.</returns>
            public ImmutableArray<XElement> ToFragments()
            {
                if (IsUnnamed)
                {
                    return ImmutableArray<XElement>.Empty;
                }

                return ImmutableArray.Create(new XElement(nameof(BuildType), new XAttribute("Name", _value)));
            }

            /// <summary>
            /// Returns the string representation of the Build.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                if (IsUnnamed)
                {
                    return string.Empty;
                }

                return ToFragments().Merge();
            }

            /// <summary>
            /// Validates the Build.
            /// </summary>
            /// <remarks>A valid value is required.</remarks>
            /// <param name="validationContext">The validation context.</param>
            /// <returns>The validation results.</returns>
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (IsUnnamed)
                {
                    yield break;
                }

                if (!rule.IsMatch(_value))
                {
                    yield return new ValidationResult(ValidateValueInvalid.Format(nameof(BuildType), _value), new[] { nameof(BuildType) });
                }
            }
        }
    }
}