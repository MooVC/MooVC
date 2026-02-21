namespace MooVC.Syntax.Attributes.Solution
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using Fluentify;
    using Monify;
    using MooVC.Syntax;
    using MooVC.Syntax.Elements;
    using static MooVC.Syntax.Attributes.Solution.File_Resources;

    /// <summary>
    /// Represents a MSBuild solution attribute file.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
    public sealed partial class File
        : IProduceXml,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly File Undefined = string.Empty;

        private static readonly Regex rule = new Regex(
            @"^(?![\\/])(?![A-Za-z]:)(?!\\\\)(?:(?:[^<>:""|?*\x00-\x1F\\/]+[\\/])*[^<>:""|?*\x00-\x1F\\/]+)$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        /// Gets a value indicating whether the File is undefined.
        /// </summary>
        /// <value>A value indicating whether the File is undefined.</value>
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Performs the to fragments operation for the MSBuild solution attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            return ImmutableArray.Create(new XElement(nameof(File), _value.ToXmlAttribute(nameof(Path))));
        }

        /// <summary>
        /// Returns the string representation of the File.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the File.
        /// </summary>
        /// <remarks>Required members include: Id, Name, Path.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                yield break;
            }

            if (_value is null || _value.Length == 0 || !rule.IsMatch(_value))
            {
                yield return new ValidationResult(ValidateValueInvalid.Format(nameof(Path), nameof(File), _value), new[] { nameof(File) });
            }
        }
    }
}