namespace MooVC.Syntax.Attributes.Resource
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
    /// Represents a resource file attribute metadata.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Metadata
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Metadata.
        /// </summary>
        public static readonly Metadata Undefined = new Metadata();

        /// <summary>
        /// Initializes a new instance of the Metadata class.
        /// </summary>
        internal Metadata()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Metadata is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the mime type on the Metadata.
        /// </summary>
        public Snippet MimeType { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the name on the Metadata.
        /// </summary>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the type on the Metadata.
        /// </summary>
        [Descriptor("OfType")]
        public Snippet Type { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the value on the Metadata.
        /// </summary>
        public Snippet Value { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the To Fragments operation for the resource file attribute.
        /// </summary>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                "metadata",
                Name.ToXmlAttribute("name"),
                Type.ToXmlAttribute("type"),
                MimeType.ToXmlAttribute("mimetype"),
                new XElement("value", Value.ToString())));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Metadata.
        /// </summary>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the Metadata and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(MimeType), _ => !MimeType.IsMultiLine, MimeType)
                .And(nameof(Name), _ => !Name.IsMultiLine, Name)
                .And(nameof(Type), _ => !Type.IsMultiLine, Type)
                .Results;
        }
    }
}