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
    public sealed partial class Header
        : IValidatableObject
    {
        public static readonly Header Undefined = new Header();

        internal Header()
        {
        }

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Snippet Name { get; internal set; } = Snippet.Empty;

        public Snippet Value { get; internal set; } = Snippet.Empty;

        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement("resheader", Name.ToXmlAttribute("name"), new XElement("value", Value.ToString())));

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
                .Include(nameof(Name), _ => !Name.IsMultiLine, Name)
                .And(nameof(Value), _ => !Value.IsMultiLine, Value)
                .Results;
        }
    }
}