namespace MooVC.Syntax.Attributes.Solution
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Fluentify;
    using Monify;
    using static MooVC.Syntax.Attributes.Solution.Folder_Resources;

    /// <summary>
    /// Represents a MSBuild solution attribute folder.
    /// </summary>
    public partial class Folder
    {
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Path
            : IValidatableObject
        {
            /// <summary>
            /// Represents the root path in the virtual hierarchy.
            /// </summary>
            public static readonly Path Root = "/";

            private static readonly Regex rule = new Regex(
                @"^\/(?!\/)(?:(?!\.{1,2}\/)[^\/\x00-\x1F]+\/)+$",
                RegexOptions.Compiled | RegexOptions.CultureInvariant);

            /// <summary>
            /// Gets a value indicating whether the current node is the root node of the hierarchy.
            /// </summary>
            /// <value>
            /// A value indicating whether the current node is the root node of the hierarchy.
            /// </value>
            public bool IsRoot => this == Root;

            /// <summary>
            /// Returns the encapsulated value verbatim.
            /// </summary>
            /// <returns>A string representation the encapsulated value verbatim.</returns>
            public override string ToString()
            {
                return _value;
            }

            /// <summary>
            /// Validates the current object's state and returns a collection of validation errors, if any.
            /// </summary>
            /// <param name="validationContext">
            /// The context information about the validation operation, including the object instance and any additional services.
            /// </param>
            /// <returns>
            /// A collection of <see cref="ValidationResult"/> objects that describe any validation errors.
            /// The collection is empty if the object is valid.
            /// </returns>
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (IsRoot)
                {
                    yield break;
                }

                if (_value is null || _value.Length == 0 || !rule.IsMatch(_value))
                {
                    yield return new ValidationResult(PathValidateValueInvalid.Format(nameof(Path), _value), new[] { nameof(Path) });
                }
            }
        }
    }
}