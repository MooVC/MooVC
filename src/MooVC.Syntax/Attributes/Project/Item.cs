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
    /// Represents a MSBuild project attribute item.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Item
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Item Undefined = new Item();

        /// <summary>
        /// Initializes a new instance of the Item class.
        /// </summary>
        internal Item()
        {
        }

        /// <summary>
        /// Gets the condition on the Item.
        /// </summary>
        /// <value>The condition.</value>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the exclude on the Item.
        /// </summary>
        /// <value>The exclude.</value>
        public Snippet Exclude { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the include on the Item.
        /// </summary>
        /// <value>The include.</value>
        public Snippet Include { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Item is undefined.
        /// </summary>
        /// <value>A value indicating whether the Item is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the keep duplicates on the Item.
        /// </summary>
        /// <value>The keep duplicates.</value>
        public bool KeepDuplicates { get; internal set; }

        /// <summary>
        /// Gets the match on metadata on the Item.
        /// </summary>
        /// <value>The match on metadata.</value>
        public Snippet MatchOnMetadata { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the match on metadata options on the Item.
        /// </summary>
        /// <value>The match on metadata options.</value>
        public Snippet MatchOnMetadataOptions { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the metadata on the Item.
        /// </summary>
        /// <value>The metadata.</value>
        public ImmutableArray<Metadata> Metadata { get; internal set; } = ImmutableArray<Metadata>.Empty;

        /// <summary>
        /// Gets the remove on the Item.
        /// </summary>
        /// <value>The remove.</value>
        public Snippet Remove { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the remove metadata on the Item.
        /// </summary>
        /// <value>The remove metadata.</value>
        public Snippet RemoveMetadata { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the update on the Item.
        /// </summary>
        /// <value>The update.</value>
        public Snippet Update { get; internal set; } = Snippet.Empty;

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

            XElement[] metadata = Metadata
                .Where(entry => !entry.IsUndefined)
                .SelectMany(entry => entry.ToFragments())
                .ToArray();

            return ImmutableArray.Create(new XElement(
                nameof(Item),
                Condition.ToXmlAttribute(nameof(Condition))
                .And(Exclude.ToXmlAttribute(nameof(Exclude)))
                .And(Include.ToXmlAttribute(nameof(Include)))
                .And(KeepDuplicates.ToXmlAttribute(nameof(KeepDuplicates)))
                .And(MatchOnMetadata.ToXmlAttribute(nameof(MatchOnMetadata)))
                .And(MatchOnMetadataOptions.ToXmlAttribute(nameof(MatchOnMetadataOptions)))
                .And(Remove.ToXmlAttribute(nameof(Remove)))
                .And(RemoveMetadata.ToXmlAttribute(nameof(RemoveMetadata)))
                .And(Update.ToXmlAttribute(nameof(Update)))
                .And(metadata)));
        }

        /// <summary>
        /// Returns the string representation of the Item.
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
        /// Validates the Item.
        /// </summary>
        /// <remarks>Required members include: Condition, Exclude, Include, MatchOnMetadata, MatchOnMetadataOptions, Metadata, Remove, RemoveMetadata, Update.</remarks>
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
                .And(nameof(Exclude), _ => !Exclude.IsMultiLine, Exclude)
                .And(nameof(Include), _ => !Include.IsMultiLine, Include)
                .And(nameof(MatchOnMetadata), _ => !MatchOnMetadata.IsMultiLine, MatchOnMetadata)
                .And(nameof(MatchOnMetadataOptions), _ => !MatchOnMetadataOptions.IsMultiLine, MatchOnMetadataOptions)
                .AndIf(!Metadata.IsDefaultOrEmpty, nameof(Metadata), metadata => !metadata.IsUndefined, Metadata)
                .And(nameof(Remove), _ => !Remove.IsMultiLine, Remove)
                .And(nameof(RemoveMetadata), _ => !RemoveMetadata.IsMultiLine, RemoveMetadata)
                .And(nameof(Update), _ => !Update.IsMultiLine, Update)
                .Results;
        }
    }
}