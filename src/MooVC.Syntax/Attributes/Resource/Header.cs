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
    /// Represents a resource file attribute header.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Header
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Header.
        /// </summary>
        public static readonly Header Undefined = new Header();

        /// <summary>
        /// Initializes a new instance of the Header class.
        /// </summary>
        internal Header()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Header is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the Header.
        /// </summary>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the value on the Header.
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

            builder.Add(new XElement("resheader", Name.ToXmlAttribute("name"), new XElement("value", Value.ToString())));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Header.
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
        /// Validates the Header and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsMultiLine, Name)
                .And(nameof(Value), _ => !Value.IsMultiLine, Value)
                .Results;
        }
    }
}