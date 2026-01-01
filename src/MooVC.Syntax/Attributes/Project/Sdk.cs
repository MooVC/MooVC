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

    [Fluentify]
    [Valuify]
    public sealed partial class Sdk
        : IValidatableObject
    {
        public static readonly Sdk Unspecified = new Sdk();

        internal Sdk()
        {
        }

        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        public Snippet MinimumVersion { get; internal set; } = Snippet.Empty;

        public Qualifier Name { get; internal set; } = Qualifier.Unqualified;

        public Snippet Version { get; internal set; } = Snippet.Empty;

        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUnspecified)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(Sdk),
                Name.ToXmlAttribute(nameof(Name)),
                Version.ToXmlAttribute(nameof(Version)),
                MinimumVersion.ToXmlAttribute(nameof(MinimumVersion))));

            return builder.ToImmutable();
        }

        public override string ToString()
        {
            if (IsUnspecified)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(MinimumVersion), _ => !MinimumVersion.IsMultiLine, MinimumVersion)
                .And(nameof(Name), _ => !Name.IsUnqualified, Name)
                .And(nameof(Version), _ => !Version.IsMultiLine, Version)
                .Results;
        }
    }
}