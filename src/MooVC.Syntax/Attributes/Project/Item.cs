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
    /// Represents a msbuild project attribute item.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Item
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Item.
        /// </summary>
        public static readonly Item Undefined = new Item();

        /// <summary>
        /// Initializes a new instance of the Item class.
        /// </summary>
        internal Item()
        {
        }

        /// <summary>
        /// Gets or sets the condition on the Item.
        /// </summary>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the exclude on the Item.
        /// </summary>
        public Snippet Exclude { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the include on the Item.
        /// </summary>
        public Snippet Include { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Item is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the keep duplicates on the Item.
        /// </summary>
        public bool KeepDuplicates { get; internal set; }

        /// <summary>
        /// Gets or sets the match on metadata on the Item.
        /// </summary>
        public Snippet MatchOnMetadata { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the match on metadata options on the Item.
        /// </summary>
        public Snippet MatchOnMetadataOptions { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the metadata on the Item.
        /// </summary>
        public ImmutableArray<Metadata> Metadata { get; internal set; } = ImmutableArray<Metadata>.Empty;

        /// <summary>
        /// Gets or sets the remove on the Item.
        /// </summary>
        public Snippet Remove { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the remove metadata on the Item.
        /// </summary>
        public Snippet RemoveMetadata { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the update on the Item.
        /// </summary>
        public Snippet Update { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the To Fragments operation for the msbuild project attribute.
        /// </summary>
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

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(Item),
                Condition.ToXmlAttribute(nameof(Condition)),
                Exclude.ToXmlAttribute(nameof(Exclude)),
                Include.ToXmlAttribute(nameof(Include)),
                KeepDuplicates.ToXmlAttribute(nameof(KeepDuplicates)),
                MatchOnMetadata.ToXmlAttribute(nameof(MatchOnMetadata)),
                MatchOnMetadataOptions.ToXmlAttribute(nameof(MatchOnMetadataOptions)),
                Remove.ToXmlAttribute(nameof(Remove)),
                RemoveMetadata.ToXmlAttribute(nameof(RemoveMetadata)),
                Update.ToXmlAttribute(nameof(Update)),
                metadata));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Item.
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
        /// Validates the Item and returns validation results.
        /// </summary>
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