namespace MooVC.Syntax.Attributes.Project
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
    /// Represents a msbuild project attribute property group.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class PropertyGroup
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the PropertyGroup.
        /// </summary>
        public static readonly PropertyGroup Undefined = new PropertyGroup();

        /// <summary>
        /// Initializes a new instance of the PropertyGroup class.
        /// </summary>
        internal PropertyGroup()
        {
        }

        /// <summary>
        /// Gets or sets the condition on the PropertyGroup.
        /// </summary>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the PropertyGroup is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the label on the PropertyGroup.
        /// </summary>
        [Descriptor("KnownAs")]
        public Snippet Label { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the properties on the PropertyGroup.
        /// </summary>
        public ImmutableArray<Property> Properties { get; internal set; } = ImmutableArray<Property>.Empty;

        /// <summary>
        /// Performs the To Fragments operation for the msbuild project attribute.
        /// </summary>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            XElement[] properties = Properties
                .Where(property => !property.IsUndefined)
                .SelectMany(property => property.ToFragments())
                .ToArray();

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(PropertyGroup),
                Condition.ToXmlAttribute(nameof(Condition)),
                Label.ToXmlAttribute(nameof(Label)),
                properties));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the PropertyGroup.
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
        /// Validates the PropertyGroup and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Condition), _ => !Condition.IsMultiLine, Condition)
                .AndIf(!Properties.IsDefaultOrEmpty, nameof(Properties), property => !property.IsUndefined, Properties)
                .And(nameof(Label), _ => !Label.IsMultiLine, Label)
                .Results;
        }
    }
}