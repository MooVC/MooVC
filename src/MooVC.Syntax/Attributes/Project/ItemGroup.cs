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
    /// Represents a MSBuild project attribute item group.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class ItemGroup
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly ItemGroup Undefined = new ItemGroup();

        /// <summary>
        /// Initializes a new instance of the ItemGroup class.
        /// </summary>
        internal ItemGroup()
        {
        }

        /// <summary>
        /// Gets or sets the condition on the ItemGroup.
        /// </summary>
        /// <value>The condition.</value>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the ItemGroup is undefined.
        /// </summary>
        /// <value>A value indicating whether the ItemGroup is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the items on the ItemGroup.
        /// </summary>
        /// <value>The items.</value>
        public ImmutableArray<Item> Items { get; internal set; } = ImmutableArray<Item>.Empty;

        /// <summary>
        /// Gets or sets the label on the ItemGroup.
        /// </summary>
        /// <value>The label.</value>
        [Descriptor("KnownAs")]
        public Snippet Label { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the to fragments operation for the MSBuild project attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            XElement[] items = Items
                .Where(item => !item.IsUndefined)
                .SelectMany(item => item.ToFragments())
                .ToArray();

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(ItemGroup),
                Condition.ToXmlAttribute(nameof(Condition)),
                Label.ToXmlAttribute(nameof(Label)),
                items));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the ItemGroup.
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
        /// Validates the ItemGroup.
        /// </summary>
        /// <remarks>Required members include: Condition, Items, Label.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Condition), _ => !Condition.IsMultiLine, Condition)
                .AndIf(!Items.IsDefaultOrEmpty, nameof(Items), item => !item.IsUndefined, Items)
                .And(nameof(Label), _ => !Label.IsMultiLine, Label)
                .Results;
        }
    }
}