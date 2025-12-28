namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Item
        : IValidatableObject
    {
        public static readonly Item Undefined = new Item();

        internal Item()
        {
        }

        public Snippet Condition { get; internal set; } = Snippet.Empty;

        public Snippet Exclude { get; internal set; } = Snippet.Empty;

        public Snippet Include { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public bool KeepDuplicates { get; internal set; }

        public Snippet MatchOnMetadata { get; internal set; } = Snippet.Empty;

        public Snippet MatchOnMetadataOptions { get; internal set; } = Snippet.Empty;

        public ImmutableArray<Metadata> Metadata { get; internal set; } = ImmutableArray<Metadata>.Empty;

        public Snippet Remove { get; internal set; } = Snippet.Empty;

        public Snippet RemoveMetadata { get; internal set; } = Snippet.Empty;

        public Snippet Update { get; internal set; } = Snippet.Empty;

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

        public XElement ToFragment()
        {
            var metadata = Metadata
                .Where(entry => !entry.IsUndefined)
                .Select(entry => entry.ToFragment());

            return new XElement(
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
                metadata);
        }

        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragment().ToString();
        }
    }
}