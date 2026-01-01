namespace MooVC.Syntax.Attributes.Solution
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
    /// Represents a msbuild solution attribute property.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Property
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Property.
        /// </summary>
        public static readonly Property Undefined = new Property();

        /// <summary>
        /// Initializes a new instance of the Property class.
        /// </summary>
        internal Property()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Property is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the Property.
        /// </summary>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the value on the Property.
        /// </summary>
        public Snippet Value { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the To Fragments operation for the msbuild solution attribute.
        /// </summary>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(Property),
                Name.ToXmlAttribute(nameof(Name)),
                Value.ToXmlAttribute(nameof(Value))));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Property.
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
        /// Validates the Property and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Name), _ => Name.IsSingleLine, Name)
                .And(nameof(Value), _ => Value.IsSingleLine, Value)
                .Results;
        }
    }
}