namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class PropertyGroup
        : IValidatableObject
    {
        public static readonly PropertyGroup Undefined = new PropertyGroup();

        internal PropertyGroup()
        {
        }

        public Snippet Condition { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Snippet Label { get; internal set; } = Snippet.Empty;

        public ImmutableArray<Property> Properties { get; internal set; } = ImmutableArray<Property>.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Condition), _ => !Condition.IsMultiLine, Condition)
                .AndIf(!Properties.IsDefaultOrEmpty, nameof(Properties), property => !property.IsUndefined, Properties)
                .And(nameof(Label), _ => !Label.IsMultiLine, Label)
                .Results;
        }

        public XElement ToFragment()
        {
            var properties = Properties
                .Where(property => !property.IsUndefined)
                .Select(property => property.ToFragment());

            return new XElement(
                nameof(PropertyGroup),
                Condition.ToXmlAttribute(nameof(Condition)),
                Label.ToXmlAttribute(nameof(Label)),
                properties);
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