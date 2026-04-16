namespace MooVC.Syntax.Resource
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents metadata associated with a resource entry in a .resx document.
    /// </summary>
    /// <remarks>
    /// Metadata is serialized as a <c>metadata</c> element with optional attributes and an optional
    /// nested <c>value</c> element.
    /// </remarks>
    [Fluentify]
    [Valuify]
    public sealed partial class Metadata
        : IProduceXml,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
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
        /// <value>A value indicating whether the Metadata is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the MIME type metadata value.
        /// </summary>
        /// <value>The MIME type metadata value.</value>
        public Snippet MimeType { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the metadata name.
        /// </summary>
        /// <value>The metadata name.</value>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the CLR type metadata value.
        /// </summary>
        /// <value>The CLR type metadata value.</value>
        [Descriptor("OfType")]
        public Snippet Type { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the metadata payload.
        /// </summary>
        /// <value>The metadata payload.</value>
        public Snippet Value { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Creates the XML fragments for the metadata element.
        /// </summary>
        /// <returns>An immutable array containing a single <see cref="XElement"/> when defined; otherwise an empty array.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            return ImmutableArray.Create(new XElement(
                nameof(Metadata).ToLowerInvariant(),
                Name.ToXmlAttribute(nameof(Name), toLower: true)
                .And(Type.ToXmlAttribute(nameof(Type), toLower: true)
                .And(MimeType.ToXmlAttribute(nameof(MimeType), toLower: true)
                .And(new XElement(nameof(Value).ToLowerInvariant(), Value.ToString()))))));
        }

        /// <summary>
        /// Returns the string representation of the metadata element.
        /// </summary>
        /// <returns>The XML representation, or <see cref="string.Empty"/> when undefined.</returns>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the metadata.
        /// </summary>
        /// <remarks>
        /// Required members include <see cref="MimeType"/>, <see cref="Name"/>, and <see cref="Type"/>.
        /// </remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
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