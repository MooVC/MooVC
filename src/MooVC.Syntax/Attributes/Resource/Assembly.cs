namespace MooVC.Syntax.Attributes.Resource
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
    public sealed partial class Assembly
        : IValidatableObject
    {
        public static readonly Assembly Undefined = new Assembly();

        internal Assembly()
        {
        }

        public Snippet Alias { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Snippet Name { get; internal set; } = Snippet.Empty;

        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement("assembly", Alias.ToXmlAttribute("alias"), Name.ToXmlAttribute("name")));

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
                .Include(nameof(Alias), _ => !Alias.IsMultiLine, Alias)
                .And(nameof(Name), _ => !Name.IsMultiLine, Name)
                .Results;
        }
    }
}