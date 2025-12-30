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
    public sealed partial class Folder
        : IValidatableObject
    {
        public static readonly Folder Undefined = new Folder();

        internal Folder()
        {
        }

        public ImmutableArray<File> Files { get; internal set; } = ImmutableArray<File>.Empty;

        public ImmutableArray<Folder> Folders { get; internal set; } = ImmutableArray<Folder>.Empty;

        public Snippet Id { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public ImmutableArray<Item> Items { get; internal set; } = ImmutableArray<Item>.Empty;

        public Snippet Name { get; internal set; } = Snippet.Empty;

        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            XElement[] files = Files
                .Where(file => !file.IsUndefined)
                .SelectMany(file => file.ToFragments())
                .ToArray();

            XElement[] folders = Folders
                .Where(folder => !folder.IsUndefined)
                .SelectMany(folder => folder.ToFragments())
                .ToArray();

            XElement[] items = Items
                .Where(item => !item.IsUndefined)
                .SelectMany(item => item.ToFragments())
                .ToArray();

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(Folder),
                Id.ToXmlAttribute(nameof(Id)),
                Name.ToXmlAttribute(nameof(Name)),
                files,
                folders,
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
                .IncludeIf(!Files.IsDefaultOrEmpty, nameof(Files), file => !file.IsUndefined, Files)
                .AndIf(!Folders.IsDefaultOrEmpty, nameof(Folders), folder => !folder.IsUndefined, Folders)
                .And(nameof(Id), _ => !Id.IsMultiLine, Id)
                .AndIf(!Items.IsDefaultOrEmpty, nameof(Items), item => !item.IsUndefined, Items)
                .And(nameof(Name), _ => Name.IsSingleLine, Name)
                .Results;
        }
    }
}