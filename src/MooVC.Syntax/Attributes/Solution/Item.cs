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

    [Fluentify]
    [Valuify]
    public sealed partial class Item
        : IValidatableObject
    {
        public static readonly Item Undefined = new Item();

        internal Item()
        {
        }

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Snippet Id { get; internal set; } = Snippet.Empty;

        public ImmutableArray<Item> Items { get; internal set; } = ImmutableArray<Item>.Empty;

        public Snippet Name { get; internal set; } = Snippet.Empty;

        public Snippet Path { get; internal set; } = Snippet.Empty;

        public Snippet Type { get; internal set; } = Snippet.Empty;

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
                nameof(Item),
                Id.ToXmlAttribute(nameof(Id)),
                Name.ToXmlAttribute(nameof(Name)),
                Path.ToXmlAttribute(nameof(Path)),
                Type.ToXmlAttribute(nameof(Type)),
                items));

            return builder.ToImmutable();
        }

        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Id), _ => !Id.IsMultiLine, Id)
                .AndIf(!Items.IsDefaultOrEmpty, nameof(Items), item => !item.IsUndefined, Items)
                .And(nameof(Name), _ => !Name.IsMultiLine, Name)
                .And(nameof(Path), _ => Path.IsSingleLine, Path)
                .And(nameof(Type), _ => Type.IsSingleLine, Type)
                .Results;
        }
    }
}