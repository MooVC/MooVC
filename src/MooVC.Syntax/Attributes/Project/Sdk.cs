namespace MooVC.Syntax.Attributes.Project
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a MSBuild project attribute sdk.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Sdk
        : IValidatableObject
    {
        /// <summary>
        /// Gets the unspecified instance.
        /// </summary>
        public static readonly Sdk Unspecified = new Sdk();

        /// <summary>
        /// Initializes a new instance of the Sdk class.
        /// </summary>
        internal Sdk()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Sdk is unspecified.
        /// </summary>
        /// <value>A value indicating whether the Sdk is unspecified.</value>
        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Gets or sets the minimum version on the Sdk.
        /// </summary>
        /// <value>The minimum version.</value>
        public Snippet MinimumVersion { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the name on the Sdk.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Qualifier Name { get; internal set; } = Qualifier.Unqualified;

        /// <summary>
        /// Gets or sets the version on the Sdk.
        /// </summary>
        /// <value>The version.</value>
        public Snippet Version { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the to fragments operation for the MSBuild project attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUnspecified)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(Sdk),
                Name.ToXmlAttribute(nameof(Name)),
                Version.ToXmlAttribute(nameof(Version)),
                MinimumVersion.ToXmlAttribute(nameof(MinimumVersion))));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Sdk.
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
        /// Validates the Sdk.
        /// </summary>
        /// <remarks>Required members include: MinimumVersion, Name, Version.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(MinimumVersion), _ => !MinimumVersion.IsMultiLine, MinimumVersion)
                .And(nameof(Name), _ => !Name.IsUnqualified, Name)
                .And(nameof(Version), _ => !Version.IsMultiLine, Version)
                .Results;
        }
    }
}