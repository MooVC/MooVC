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
    /// Provides configuration-related types and utilities for managing platform targets and build settings.
    /// </summary>
    public partial class Configurations
    {
        /// <summary>
        /// Represents a platform identifier, such as a processor architecture or target runtime, for use in build
        /// configurations and solution attributes.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Platform
            : IProduceXml,
              IValidatableObject
        {
            /// <summary>
            /// Represents an unspecified or unknown platform value.
            /// </summary>
            public static readonly Platform Unspecified = string.Empty;

            /// <summary>
            /// Represents a platform target that is compatible with both 32-bit and 64-bit architectures.
            /// </summary>
            public static readonly Platform AnyCPU = "Any CPU";

            /// <summary>
            /// Represents the ARM processor architecture platform.
            /// </summary>
            public static readonly Platform ARM = "ARM";

            /// <summary>
            /// Represents the ARM64 platform architecture.
            /// </summary>
            public static readonly Platform ARM64 = "ARM64";

            #pragma warning disable SA1307 // Accessible fields should begin with upper-case letter

            /// <summary>
            /// Represents the 64-bit x64 platform identifier.
            /// </summary>
            public static readonly Platform x64 = "x64";

            /// <summary>
            /// Represents the x86 (32-bit) platform architecture.
            /// </summary>
            public static readonly Platform x86 = "x86";
            #pragma warning restore SA1307 // Accessible fields should begin with upper-case letter

            private static readonly Regex rule = new Regex(@"^(?!\s)[^\x00-\x1F\x7F""<>]{1,64}(?<!\s)$", RegexOptions.Compiled);

            /// <summary>
            /// Gets a value indicating whether the current instance represents an unspecified value.
            /// </summary>
            /// <value>
            /// A value indicating whether the current instance represents an unspecified value.
            /// </value>
            public bool IsUnspecified => this == Unspecified;

            /// <summary>
            /// Performs the to fragments operation for the MSBuild solution attribute.
            /// </summary>
            /// <returns>The immutable array x element.</returns>
            public ImmutableArray<XElement> ToFragments()
            {
                if (IsUnspecified)
                {
                    return ImmutableArray<XElement>.Empty;
                }

                return ImmutableArray.Create(new XElement(nameof(Platform), new XAttribute("Name", _value)));
            }

            /// <summary>
            /// Returns the string representation of the Build.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                if (IsUnspecified)
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
                if (IsUnspecified)
                {
                    yield break;
                }

                if (!rule.IsMatch(_value))
                {
                    yield return new ValidationResult(ValidateValueInvalid.Format(nameof(Platform), _value), new[] { nameof(Platform) });
                }
            }
        }
    }
}