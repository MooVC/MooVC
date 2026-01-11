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
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Data Undefined = new Data();

        /// <summary>
        /// Initializes a new instance of the Data class.
        /// </summary>
        internal Data()
        {
        }

        /// <summary>
        /// Gets the comment on the Data.
        /// </summary>
        /// <value>The comment.</value>
        public Snippet Comment { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Data is undefined.
        /// </summary>
        /// <value>A value indicating whether the Data is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the mime type on the Data.
        /// </summary>
        /// <value>The mime type.</value>
        public Snippet MimeType { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the name on the Data.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the type on the Data.
        /// </summary>
        /// <value>The type.</value>
        [Descriptor("OfType")]
        public Snippet Type { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the value on the Data.
        /// </summary>
        /// <value>The value.</value>
        public Snippet Value { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the to fragments operation for the resource file attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            var element = new XElement(
                nameof(Data).ToLowerInvariant(),
                Name.ToXmlAttribute(nameof(Name), toLower: true)
                .And(Type.ToXmlAttribute(nameof(Type), toLower: true))
                .And(MimeType.ToXmlAttribute(nameof(MimeType), toLower: true))
                .And(new XElement(nameof(Value).ToLowerInvariant(), Value.ToString())));

            if (!Comment.IsEmpty)
            {
                element.Add(new XElement(nameof(Comment).ToLowerInvariant(), Comment.ToString()));
            }

            return ImmutableArray.Create(element);
        }

        /// <summary>
        /// Returns the string representation of the Data.
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
        /// Validates the Data.
        /// </summary>
        /// <remarks>Required members include: MimeType, Name, Type.</remarks>
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