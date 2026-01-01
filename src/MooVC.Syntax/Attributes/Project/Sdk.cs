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
    /// Represents a msbuild project attribute sdk.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Sdk
        : IValidatableObject
    {
        /// <summary>
        /// Gets the unspecified on the Sdk.
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
        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Gets or sets the minimum version on the Sdk.
        /// </summary>
        public Snippet MinimumVersion { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the name on the Sdk.
        /// </summary>
        [Descriptor("Named")]
        public Qualifier Name { get; internal set; } = Qualifier.Unqualified;

        /// <summary>
        /// Gets or sets the version on the Sdk.
        /// </summary>
        public Snippet Version { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the To Fragments operation for the msbuild project attribute.
        /// </summary>
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
        public override string ToString()
        {
            if (IsUnspecified)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the Sdk and returns validation results.
        /// </summary>
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