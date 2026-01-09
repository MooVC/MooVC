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
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Assembly Undefined = new Assembly();

        /// <summary>
        /// Initializes a new instance of the Assembly class.
        /// </summary>
        internal Assembly()
        {
        }

        /// <summary>
        /// Gets the alias on the Assembly.
        /// </summary>
        /// <value>The alias.</value>
        [Descriptor("KnownAs")]
        public Snippet Alias { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Assembly is undefined.
        /// </summary>
        /// <value>A value indicating whether the Assembly is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the name on the Assembly.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

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

            return ImmutableArray.Create(new XElement(
                nameof(Assembly),
                Alias.ToXmlAttribute(nameof(Alias))
                .And(Name.ToXmlAttribute(nameof(Name)))));
        }

        /// <summary>
        /// Returns the string representation of the Assembly.
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
        /// Validates the Assembly.
        /// </summary>
        /// <remarks>Required members include: Alias, Name.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
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