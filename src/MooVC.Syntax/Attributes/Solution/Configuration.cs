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
    /// Represents a MSBuild solution attribute configuration.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Configuration
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Configuration Undefined = new Configuration();

        /// <summary>
        /// Initializes a new instance of the Configuration class.
        /// </summary>
        internal Configuration()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Configuration is undefined.
        /// </summary>
        /// <value>A value indicating whether the Configuration is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the Configuration.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the platform on the Configuration.
        /// </summary>
        /// <value>The platform.</value>
        [Descriptor("For")]
        public Snippet Platform { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the to fragments operation for the MSBuild solution attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(Configuration),
                Name.ToXmlAttribute(nameof(Name)),
                Platform.ToXmlAttribute(nameof(Platform))));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Configuration.
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
        /// Validates the Configuration.
        /// </summary>
        /// <remarks>Required members include: Name, Platform.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Name), _ => Name.IsSingleLine, Name)
                .And(nameof(Platform), _ => Platform.IsSingleLine, Platform)
                .Results;
        }
    }
}