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
    /// Represents a resource file attribute data.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Data
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Data.
        /// </summary>
        public static readonly Data Undefined = new Data();

        /// <summary>
        /// Initializes a new instance of the Data class.
        /// </summary>
        internal Data()
        {
        }

        /// <summary>
        /// Gets or sets the comment on the Data.
        /// </summary>
        public Snippet Comment { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Data is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the mime type on the Data.
        /// </summary>
        public Snippet MimeType { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the name on the Data.
        /// </summary>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the type on the Data.
        /// </summary>
        [Descriptor("OfType")]
        public Snippet Type { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the value on the Data.
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

            var element = new XElement(
                "data",
                Name.ToXmlAttribute("name"),
                Type.ToXmlAttribute("type"),
                MimeType.ToXmlAttribute("mimetype"),
                new XElement("value", Value.ToString()));

            if (!Comment.IsEmpty)
            {
                element.Add(new XElement("comment", Comment.ToString()));
            }

            builder.Add(element);

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Data.
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
        /// Validates the Data and returns validation results.
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