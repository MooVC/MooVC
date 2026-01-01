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
    /// Represents a resource file attribute assembly.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Assembly
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Assembly.
        /// </summary>
        public static readonly Assembly Undefined = new Assembly();

        /// <summary>
        /// Initializes a new instance of the Assembly class.
        /// </summary>
        internal Assembly()
        {
        }

        /// <summary>
        /// Gets or sets the alias on the Assembly.
        /// </summary>
        [Descriptor("KnownAs")]
        public Snippet Alias { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Assembly is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the Assembly.
        /// </summary>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

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

            builder.Add(new XElement("assembly", Alias.ToXmlAttribute("alias"), Name.ToXmlAttribute("name")));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Assembly.
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
        /// Validates the Assembly and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Alias), _ => !Alias.IsMultiLine, Alias)
                .And(nameof(Name), _ => !Name.IsMultiLine, Name)
                .Results;
        }
    }
}