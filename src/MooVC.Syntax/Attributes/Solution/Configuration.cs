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
    /// Represents a msbuild solution attribute configuration.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Configuration
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Configuration.
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
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the Configuration.
        /// </summary>
        [Descriptor("Named")]
        public Snippet Name { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the platform on the Configuration.
        /// </summary>
        [Descriptor("For")]
        public Snippet Platform { get; internal set; } = Snippet.Empty;

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
                nameof(Configuration),
                Name.ToXmlAttribute(nameof(Name)),
                Platform.ToXmlAttribute(nameof(Platform))));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Configuration.
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
        /// Validates the Configuration and returns validation results.
        /// </summary>
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