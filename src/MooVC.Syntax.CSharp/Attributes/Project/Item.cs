namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
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

        public Identifier ItemType { get; internal set; } = Identifier.Unnamed;

        public Snippet Label { get; internal set; } = Snippet.Empty;

        public ImmutableArray<Metadata> Metadata { get; internal set; } = ImmutableArray<Metadata>.Empty;

        public Snippet Remove { get; internal set; } = Snippet.Empty;

        public Snippet Update { get; internal set; } = Snippet.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(ItemType), _ => !ItemType.IsUnnamed, ItemType)
                .AndIf(!Metadata.IsDefaultOrEmpty, nameof(Metadata), metadata => !metadata.IsUndefined, Metadata)
                .Results;
        }
    }
}