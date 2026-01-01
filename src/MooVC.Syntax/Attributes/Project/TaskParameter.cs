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
    /// Represents a msbuild project attribute task parameter.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class TaskParameter
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the TaskParameter.
        /// </summary>
        public static readonly TaskParameter Undefined = new TaskParameter();

        /// <summary>
        /// Initializes a new instance of the TaskParameter class.
        /// </summary>
        internal TaskParameter()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the TaskParameter is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the TaskParameter.
        /// </summary>
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the value on the TaskParameter.
        /// </summary>
        public Snippet Value { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the To Fragments operation for the msbuild project attribute.
        /// </summary>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                "Parameter",
                Name.ToXmlAttribute(nameof(Name)),
                Value.ToString()));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the TaskParameter.
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
        /// Validates the TaskParameter and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsUnnamed, Name)
                .And(nameof(Value), _ => !Value.IsMultiLine, Value)
                .Results;
        }
    }
}