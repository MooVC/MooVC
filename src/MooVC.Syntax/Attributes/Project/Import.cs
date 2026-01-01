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
    public sealed partial class Import
        : IValidatableObject
    {
        public static readonly Import Undefined = new Import();

        internal Import()
        {
        }

        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        [Descriptor("KnownAs")]
        public Snippet Label { get; internal set; } = Snippet.Empty;

        [Descriptor("ForProject")]
        public Snippet Project { get; internal set; } = Snippet.Empty;

        public Snippet Sdk { get; internal set; } = Snippet.Empty;

        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(Import),
                Project.ToXmlAttribute(nameof(Project)),
                Sdk.ToXmlAttribute(nameof(Sdk)),
                Condition.ToXmlAttribute(nameof(Condition)),
                Label.ToXmlAttribute(nameof(Label))));

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
                .Include(nameof(Condition), _ => !Condition.IsMultiLine, Condition)
                .And(nameof(Label), _ => !Label.IsMultiLine, Label)
                .And(nameof(Project), _ => Project.IsSingleLine, Project)
                .And(nameof(Sdk), _ => !Sdk.IsMultiLine, Sdk)
                .Results;
        }
    }
}